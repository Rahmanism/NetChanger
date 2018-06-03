using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NetChanger
{
    class NetSettings
    {
        private string interfaceName;
        private string address;
        private string netMask;
        private string gateway;

        /// <summary>
        /// Validation pattern to check IP with regex.
        /// </summary>
        private string IPValidationRegexPattern
            => @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        /// <summary>
        /// Regex variable to check IP using IPValidationRegexPattern.
        /// </summary>
        private Regex IPValidation => new Regex( IPValidationRegexPattern );

        public bool IsStatic { get; set; } = false;

        public string InterfaceName {
            get { return interfaceName; }
            set {
                var v = value.Trim();
                if ( v.Length > 1 ) {
                    interfaceName = value;
                }
                else {
                    throw new NullReferenceException( "Interface name cannot be blank." );
                }
            }
        }


        public string Address {
            get { return address; }
            set {
                var v = value?.Trim();
                if ( !IsStatic || IPValidation.IsMatch( v ) ) {
                    address = v;
                }
                else {
                    throw new RegexMatchTimeoutException( "The address isn't a correct IP." );
                }
            }
        }

        public string NetMask {
            get { return netMask; }
            set {
                var v = value?.Trim();
                if ( !IsStatic || IPValidation.IsMatch( v ) ) {
                    netMask = v;
                }
                else {
                    throw new RegexMatchTimeoutException( "NetMask isn't a correct IP." );
                }
            }
        }

        public string Gateway {
            get { return gateway; }
            set {
                var v = value?.Trim();
                // gateway can by null even when IP is static.
                if ( v == null || v.Length == 0 || IPValidation.IsMatch( v ) ) {
                    gateway = v;
                }
                else {
                    throw new RegexMatchTimeoutException( "Gateway isn't a correct IP." );
                }
            }
        }
        public List<string> Nameservers { get; set; }
    }
}
