using Microsoft.Win32;

namespace NetChanger
{
    internal class Proxy
    {
        const string INTERNET_SETTINGS = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        RegistryKey onKey = Registry.CurrentUser.OpenSubKey(INTERNET_SETTINGS, true);

        public bool IsOn ()
        {
            var name = "ProxyEnable";
            var value = (int)onKey.GetValue(name);
            return value == 1;
        }
    }
}
