using System.Collections.Generic;

namespace NetChanger
{
    /// <summary>
    /// It contains properties of network adapter mostly IP info.
    /// </summary>
    class NetProperties
    {
        public Profile Profile = new Profile();

        private byte index = 2; // just a counter for nameservers.

        #region COMMANDS

        #region STATIC IP COMMANDS
        /// <summary>
        /// A command to execute in cmd to set the IP address.
        /// </summary>
        public string SetIPCommand
            => $"netsh interface ipv4 set address name=\"{Profile.Settings.InterfaceName}\" static {Profile.Settings.Address} {Profile.Settings.NetMask} {Profile.Settings.Gateway}";

        /// <summary>
        /// A command to execute in cmd to set first DNS.
        /// </summary>
        public string SetFirstDnsCommand
            => $"netsh interface ipv4 set dns name=\"{Profile.Settings.InterfaceName}\" static {Profile.Settings.Nameservers[0]}";

        /// <summary>
        /// A command to execute in cmd to set second DNS.
        /// </summary>
        public string SetSecondDnsCommand
            => $"netsh interface ipv4 add dns name=\"{Profile.Settings.InterfaceName}\" {Profile.Settings.Nameservers[index - 1]} index={index}";

        /// <summary>
        /// Returns an array of strings that contains all necessary commands for static IP.
        /// </summary>
        public string[] StaticIPCommand {
            get {
                List<string> commands = new List<string> {
                    SetIPCommand,
                    SetFirstDnsCommand
                };
                for ( index = 2; index <= Profile.Settings.Nameservers.Count; index++ ) {
                    commands.Add( SetSecondDnsCommand );
                }
                index = 2;
                return commands.ToArray();
            }
        }
        #endregion

        #region DHCP COMMANDS
        /// <summary>
        /// A command to execute in cmd to enable DHCP.
        /// </summary>
        public string SetDHCPForIP
            => $"netsh interface ipv4 set address name=\"{Profile.Settings.InterfaceName}\" source=dhcp";

        /// <summary>
        /// A command to execute in cmd to enable DHCP for DNS.
        /// </summary>
        public string SetDHCPForDNS
            => $"netsh interface ipv4 set dns \"{Profile.Settings.InterfaceName}\" dhcp";

        /// <summary>
        /// Returns an array of strings that contains all necessary commands for IP from DHCP.
        /// </summary>
        public string[] DHCPCommand {
            get {
                List<string> commands = new List<string> {
                    SetDHCPForIP
                    // TODO: I should add a command for gateway in dhcp mode if there was a gateway ip in profile.
                };

                // If there's no dns set the dns to dhcp
                if ( Profile.Settings.Nameservers.Count < 1 ) {
                    commands.Add( SetDHCPForDNS );
                }
                else { // else set the nameservers
                    commands.Add( SetFirstDnsCommand );
                    for ( index = 2; index <= Profile.Settings.Nameservers.Count; index++ ) {
                        commands.Add( SetSecondDnsCommand );
                    }
                    index = 2;
                }
                return commands.ToArray();
            }
        }
        #endregion

        /// <summary>
        /// An array of strings that contains the final executive commands, based on Static property
        /// </summary>
        public string[] Do => Profile.Settings.IsStatic ? StaticIPCommand : DHCPCommand;

        #endregion

        // TODO: do some controls on values for IPs.

        /// <summary>
        /// A counter for nameservers
        /// </summary>
        public byte Index {
            get {
                return index;
            }
            set {
                index = (byte)System.Math.Abs( value );
            }
        }
    }
}
