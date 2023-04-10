using Microsoft.Win32;

namespace NetChanger
{
    public class ProxySettings
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
        public void TurnOn()
        {
            key.SetValue(ENABLE, 1);
        }

        /// <summary>
        /// Turns off the system proxy via registry.
        /// </summary>
        public void TurnOff()
        {
            key.SetValue(ENABLE, 0);
        }

        /// <summary>
        /// Changes proxy override via registry.
        /// </summary>
        /// <param name="overrideText">Bunch of URLs and IPs
        /// separated with ; which be ignored by proxy server.</param>
        public void ChangeProxyOverride(string overrideText)
        {
            key.SetValue(OVERRIDE, overrideText);
        }

        /// <summary>
        /// Gets the current override addresses from registry.
        /// </summary>
        /// <returns></returns>
        public string? GetProxyOverride()
        {
            return key.GetValue(OVERRIDE)?.ToString();
        }

        /// <summary>
        /// Changes proxy server and port via registry.
        /// </summary>
        /// <param name="server">Proxy server IP (or address) - default is 127.0.0.1</param>
        /// <param name="port">Proxy server port number - default is 1080</param>
        public void ChangeProxyServer(string server = "127.0.0.1", string port = "1080")
        {
            key.SetValue(SERVER, $"{server}:{port}");
        }

        /// <summary>
        /// Gets the current proxy ip and port from registry.
        /// </summary>
        /// <returns>An string array of 2
        /// which contains ip and port of current proxy server.</returns>
        public string[]? GetProxyServer()
        {
            string? server = key.GetValue(SERVER)?.ToString();
            if (server == null)
                return null;
            string[] result = server.Split(':');
            return result;
        }
    }
}
