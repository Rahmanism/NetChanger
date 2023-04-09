using Microsoft.Win32;
using System;

namespace NetChanger
{
    internal class ProxySettings
    {
        const string INTERNET_SETTINGS = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        readonly RegistryKey key = Registry.CurrentUser.OpenSubKey(INTERNET_SETTINGS, true);

        const string ENABLE = "ProxyEnable";
        const string OVERRIDE = "ProxyOverride";
        const string SERVER = "ProxyServer";

        public bool IsOn()
        {
            var value = (int)key.GetValue(ENABLE);
            return value == 1;
        }

        /// <summary>
        /// Turns on the system proxy via registry.
        /// </summary>
        /// <returns>Successful message or exception error message</returns>
        public string TurnOn()
        {
            try {
                key.SetValue(ENABLE, 1);
            }
            catch (Exception x) {
                return x.Message;
            }

            return "Proxy enabled";
        }

        /// <summary>
        /// Turns off the system proxy via registry.
        /// </summary>
        /// <returns>Successful message or exception error message</returns>
        public string TurnOff()
        {
            try {
                key.SetValue(ENABLE, 0);
            }
            catch (Exception x) {
                return x.Message;
            }

            return "Proxy disabled";
        }
    }
}
