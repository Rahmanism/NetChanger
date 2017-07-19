using System.Configuration;

namespace NetChanger
{
    /// <summary>
    /// It contains properties of network adapter mostly IP info.
    /// </summary>
    class NetProperties
    {
        private string iface = "Wi-Fi";
        private string address = "192.168.1.2";
        private string netmask = "255.255.255.0";
        private string gateway = "192.168.1.1";
        private string dnsOne = "8.8.8.8";
        private string dnsTwo = "4.2.2.4";
        private bool isStatic = false;

        #region COMMANDS

        #region STATIC IP COMMANDS
        /// <summary>
        /// A command to execute in cmd to set the IP address.
        /// </summary>
        public string SetIPCommand
            => $"netsh interface ipv4 set address name=\"{InterfaceName}\" static {Address} {NetMask} {Gateway}";

        /// <summary>
        /// A command to execute in cmd to set first DNS.
        /// </summary>
        public string SetFirstDnsCommand
            => $"netsh interface ipv4 set dns name=\"{InterfaceName}\" static {DnsOne}";

        /// <summary>
        /// A command to execute in cmd to set second DNS.
        /// </summary>
        public string SetSecondDnsCommand
            => $"netsh interface ipv4 add dns name=\"{InterfaceName}\" {DnsTwo} index=2";

        /// <summary>
        /// Returns an array of strings that contains all necessary commands for static IP.
        /// </summary>
        public string[] StaticIPCommand
            => new string[] { SetIPCommand, SetFirstDnsCommand, SetSecondDnsCommand };
        #endregion

        #region DHCP COMMANDS
        /// <summary>
        /// A command to execute in cmd to enable DHCP.
        /// </summary>
        public string SetDHCPForIP
            => $"netsh interface ipv4 set address name=\"{InterfaceName}\" source=dhcp";

        /// <summary>
        /// A command to execute in cmd to enable DHCP for DNS.
        /// </summary>
        public string SetDHCPForDNS
            => $"netsh interface ipv4 set dns \"{InterfaceName}\" dhcp";

        /// <summary>
        /// Returns an array of strings that contains all necessary commands for IP from DHCP.
        /// </summary>
        public string[] DHCPCommand
            => new string[] { SetDHCPForIP, SetDHCPForDNS };
        #endregion

        /// <summary>
        /// An array of strings that contains the final executive commands, based on Static property
        /// </summary>
        public string[] Do => Static ? StaticIPCommand : DHCPCommand;

        #endregion

        #region IPs
        // TODO: do some controls on values for IPs.

        /// <summary>
        /// IPv4 address
        /// </summary>
        public string Address {
            get {
                return address;
            }
            set {
                address = value.Trim();
            }
        }

        /// <summary>
        /// Net mask for IPv4
        /// </summary>
        public string NetMask {
            get {
                return netmask;
            }
            set {
                netmask = value.Trim();
            }
        }

        /// <summary>
        /// Gateway for IPv4
        /// </summary>
        public string Gateway {
            get {
                return gateway;
            }
            set {
                gateway = value.Trim();
            }
        }

        /// <summary>
        /// First DNS for IPv4
        /// </summary>
        public string DnsOne {
            get {
                return dnsOne;
            }
            set {
                dnsOne = value.Trim();
            }
        }

        /// <summary>
        /// Second DNS for IPv4
        /// </summary>
        public string DnsTwo {
            get {
                return dnsTwo;
            }
            set {
                dnsTwo = value.Trim();
            }
        }
        #endregion

        /// <summary>
        /// The network interface name that will be set.
        /// </summary>
        public string InterfaceName {
            get {
                return iface;
            }
            set {
                iface = value.Trim();
            }
        }

        /// <summary>
        /// IP is static or DHCP. If true it'll be static.
        /// </summary>
        public bool Static {
            get { return isStatic; }
            set { isStatic = value; }
        }
    }
}
