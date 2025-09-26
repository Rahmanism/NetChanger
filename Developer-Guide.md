This developer guide is crafted for the project **Rahmanism/NetChanger**. Given that the repository's source code is not directly available for inspection, this guide is based on the strong inference that "NetChanger" is a **C# / .NET application** designed to manage and change local **Windows Network Adapter settings** (IP Address, Subnet Mask, Gateway, DNS Servers).

The guide provides extensive detail on the expected architecture, core classes, and the low-level code implementations necessary for such a utility, focusing on the two primary methods used in C# for this purpose: **Windows Management Instrumentation (WMI)** and the **`netsh` command-line utility**.

---

# 🌐 NetChanger Developer Guide

## I. Project Overview and Goals

**Project Name:** NetChanger
**Technology Stack:** C# (likely targeting .NET Framework or .NET Core), Windows Forms / WPF (for UI, if applicable)
**Core Functionality:** Programmatically managing the network configuration of a local machine's network adapters.

### Primary Goals

1.  **Enumerate Adapters:** List all available network adapters on the system.
2.  **Read Configuration:** Retrieve the current IP, Subnet, Gateway, and DNS settings for a selected adapter.
3.  **Apply Static Configuration:** Set a new static IP address, Subnet Mask, and Default Gateway.
4.  **Apply DHCP Configuration:** Switch the adapter back to automatic (DHCP) configuration.
5.  **Manage DNS:** Set specific primary and secondary DNS servers or switch back to automatic DNS.

### Security Note

Network configuration requires elevated permissions. The application must be run **as an Administrator** for any changes to be successfully applied, particularly when using WMI or `netsh`.

---

## II. Code Architecture and Key Components

The project should follow a layered architecture, separating the User Interface, Business Logic, and System Interaction layers for maintainability.

| Layer | Component/Namespace | Responsibility | Key Classes |
| :--- | :--- | :--- | :--- |
| **Data/Model** | `NetChanger.Models` | Defines the structure for network data. | `NetworkAdapterConfig`, `IPConfig` |
| **Service/Logic** | `NetChanger.Services` | Contains the core logic for reading and applying configuration changes. This is the **most critical layer**. | `NetworkService`, `WmiHelper` / `NetshHelper` |
| **Presentation** | `NetChanger.UI` | Handles user interaction and displays data (e.g., WinForms or WPF). | `MainForm` / `MainWindow`, `AdapterViewModel` |

### A. Data/Model Layer (`NetChanger.Models`)

The data model holds the configuration state.

#### **`NetworkAdapterConfig.cs`**

This class encapsulates all relevant data for a single network interface.

```csharp
using System.Net.NetworkInformation;

namespace NetChanger.Models
{
    public class NetworkAdapterConfig
    {
        // Unique identifier for the adapter, often used by WMI or netsh
        public string AdapterId { get; set; }

        // Friendly Name of the adapter (e.g., "Ethernet", "Wi-Fi")
        public string Name { get; set; }

        // The MAC address
        public PhysicalAddress MacAddress { get; set; }

        // Current status (Up, Down, Unknown)
        public OperationalStatus Status { get; set; }

        // IP Configuration
        public IPConfig CurrentIPConfig { get; set; }
    }

    public class IPConfig
    {
        public bool IsDhcpEnabled { get; set; }
        public string IPAddress { get; set; }
        public string SubnetMask { get; set; }
        public string DefaultGateway { get; set; }
        public string[] DnsServers { get; set; }
    }
}
```

### B. Service/Logic Layer (`NetChanger.Services`) - **The Core**

This layer contains the low-level code responsible for interacting with the operating system.

#### **`INetworkService.cs`**

Define an interface to allow for dependency injection and easy switching between implementation methods (WMI vs. `netsh`).

```csharp
namespace NetChanger.Services
{
    public interface INetworkService
    {
        // Get all available adapters and their current configuration
        List<NetworkAdapterConfig> GetAdapters();

        // Set static IP configuration
        bool SetStaticIP(string adapterId, string ipAddress, string subnetMask, string gateway);

        // Enable DHCP (automatic IP)
        bool EnableDhcp(string adapterId);

        // Set static DNS servers
        bool SetStaticDns(string adapterId, string primaryDns, string secondaryDns = null);

        // Enable DHCP for DNS
        bool EnableDhcpDns(string adapterId);
    }
}
```

#### **`WmiNetworkService.cs` - Implementation Details (WMI)**

WMI is the most common programmatic way to change settings in C#. It uses the `System.Management` namespace. The key class is `Win32_NetworkAdapterConfiguration`.

**1. Enabling DHCP (Code Detail)**

```csharp
using System.Management;

public class WmiNetworkService : INetworkService
{
    public bool EnableDhcp(string adapterId)
    {
        // WMI Query to find the adapter configuration object
        string query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE SettingID='{adapterId}'";
        
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
        {
            ManagementObject config = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

            if (config != null)
            {
                // Call the EnableDHCP method on the WMI object
                ManagementBaseObject newSettings = config.InvokeMethod("EnableDHCP", null);
                
                // Return value of 0 means success
                return (uint)newSettings["ReturnValue"] == 0;
            }
        }
        return false;
    }
    // ... other methods
}
```

**2. Setting a Static IP (Code Detail)**

```csharp
public bool SetStaticIP(string adapterId, string ipAddress, string subnetMask, string gateway)
{
    // ... (WMI searcher logic to get the 'config' object, similar to EnableDhcp)

    if (config != null)
    {
        ManagementBaseObject newIP = config.GetMethodParameters("EnableStatic");
        ManagementBaseObject newGateway = config.GetMethodParameters("SetGateways");

        // Set IP and Subnet
        newIP["IPAddress"] = new string[] { ipAddress };
        newIP["SubnetMask"] = new string[] { subnetMask };

        // Set Gateway
        newGateway["DefaultIPGateway"] = new string[] { gateway };
        newGateway["GatewayCostMetric"] = new int[] { 1 }; // Default metric

        // Invoke the methods
        uint ipResult = (uint)config.InvokeMethod("EnableStatic", newIP, null)["ReturnValue"];
        uint gatewayResult = (uint)config.InvokeMethod("SetGateways", newGateway, null)["ReturnValue"];

        // A return value of 0 is successful, 1 is successful but a reboot is required (rare for IP)
        return ipResult <= 1 && gatewayResult <= 1;
    }
    return false;
}
```

#### **`NetshNetworkService.cs` - Implementation Details (`netsh`)**

This alternative implementation avoids WMI complexity by executing the native Windows `netsh` command-line utility. This method is often simpler but relies on string formatting and external process execution.

**1. Enabling DHCP (Code Detail)**

```csharp
using System.Diagnostics;
using NetChanger.Models; // Assume AdapterId is the Interface Name for netsh

public class NetshNetworkService : INetworkService
{
    private bool ExecuteNetshCommand(string arguments)
    {
        using (Process process = new Process())
        {
            process.StartInfo.FileName = "netsh";
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true; // Essential for a UI app

            process.Start();
            process.WaitForExit();

            // netsh commands typically exit with code 0 on success
            // In a real project, you would also read and parse process.StandardOutput
            return process.ExitCode == 0; 
        }
    }

    public bool EnableDhcp(string adapterId)
    {
        // interface ip set address "Adapter Name" dhcp
        string arguments = $"interface ip set address \"{adapterId}\" dhcp";
        return ExecuteNetshCommand(arguments);
    }
    // ... other methods
}
```

**2. Setting Static DNS (Code Detail)**

```csharp
public bool SetStaticDns(string adapterId, string primaryDns, string secondaryDns = null)
{
    // interface ip set dns "Adapter Name" static <primary>
    string setPrimaryArgs = $"interface ip set dns \"{adapterId}\" static {primaryDns} primary";
    bool primarySuccess = ExecuteNetshCommand(setPrimaryArgs);

    if (primarySuccess && !string.IsNullOrEmpty(secondaryDns))
    {
        // interface ip add dns "Adapter Name" <secondary> index=2
        string addSecondaryArgs = $"interface ip add dns \"{adapterId}\" {secondaryDns} index=2";
        return ExecuteNetshCommand(addSecondaryArgs);
    }
    
    return primarySuccess;
}
```

---

## III. Prerequisites and Development Setup

### 1. Prerequisites

*   **Operating System:** Windows (Desktop versions like Windows 10/11, as WMI and `netsh` are Windows-specific).
*   **SDK:** .NET Framework (e.g., 4.7.2 or later) or .NET Core / .NET (e.g., .NET 6/7/8) SDK.
*   **IDE:** Visual Studio (Community or Professional).

### 2. Project Dependencies

If using WMI, the following NuGet package is required:

```bash
Install-Package System.Management
```

If the UI is a modern WPF or WinForms app, you may need additional packages for MVVM, like **Microsoft.Toolkit.Mvvm**.

### 3. Cloning and Building

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/Rahmanism/NetChanger.git
    cd NetChanger
    ```
2.  **Open in Visual Studio:**
    *   Open the solution file (`.sln`) in Visual Studio.
3.  **Restore Dependencies:**
    *   Visual Studio should automatically restore NuGet packages, or you can run:
    ```bash
    dotnet restore
    ```
4.  **Build the Project:**
    *   Select the **Release** or **Debug** configuration.
    *   Build the solution (Build -> Build Solution or **Ctrl+Shift+B**).

---

## IV. Contributing Guidelines

### 1. Style and Standards

*   Follow **Microsoft's C# Naming Conventions** (PascalCase for classes/methods, camelCase for parameters/local variables).
*   Use `var` judiciously where the type is obvious.
*   Keep logic in the **`Services`** layer and UI logic in the **`Presentation`** layer.

### 2. Implementing New Features (e.g., IPv6 Support)

To add IPv6 support, developers must primarily focus on updating the `INetworkService` and its concrete implementations:

1.  **Update Models:** Modify `IPConfig` to include properties like `IPv6Address`, `IPv6Gateway`, and a mechanism to store multiple IPv6 DNS servers.
2.  **Update Interface:** Add new methods to `INetworkService`:
    ```csharp
    bool SetStaticIPv6(string adapterId, string ipv6Address, int prefixLength, string gateway);
    // etc.
    ```
3.  **Implement in `WmiNetworkService`:**
    *   WMI uses the `EnableStatic` and `SetGateways` methods, but the parameters must be adjusted to handle IPv6 arrays.
    *   WMI method: `EnableStatic(IPAddress, SubnetMask)` (for IPv4) vs. `EnableStatic(IPAddress, SubnetMask, IPAddressType)` (where `IPAddressType` can specify IPv6).
4.  **Implement in `NetshNetworkService`:**
    *   The `netsh` commands are different for IPv6:
    ```bash
    # IPv6 Static IP command
    netsh interface ipv6 set address "Adapter Name" static <ipv6-address> <prefix-length>
    ```

### 3. Testing and Debugging

The Service layer should be tested with **mock** objects to simulate network adapter responses without actually changing system settings.

*   **Unit Tests (`NetChanger.Tests`)**:
    *   Test the `NetworkService` implementations by wrapping the WMI/`netsh` interactions with a mockable system interaction layer (e.g., a `ISystemCommandExecutor` interface).
    *   Verify that `SetStaticIP` correctly formats the WMI parameters or the `netsh` command string.
*   **Debugging Configuration Changes**:
    *   When debugging configuration changes, always check the `ReturnValue` (for WMI) or the `ExitCode` (for `netsh` process). Any non-zero value indicates a failure, often due to permission issues or incorrect parameter formatting.
    *   Use a try-catch block to specifically log and handle `System.Management.ManagementException` if using WMI, as this provides detailed error codes.
