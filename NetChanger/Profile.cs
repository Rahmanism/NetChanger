using System;
using System.Collections.Generic;

namespace NetChanger
{
    class Profile
    {
        private string name;

        public string Name {
            get { return name; }
            set {
                var v = value.Trim();
                if ( v.Length > 1 ) {
                    name = value;
                }
                else {
                    throw new NullReferenceException( Resources.Resources.no_blank_name );
                }
            }
        }

        public NetSettings Settings { get; set; }

        public Profile()
        {
        }

        /// <summary>
        /// A constructor that will create a copy from another profile.
        /// </summary>
        /// <param name="source"></param>
        public Profile(Profile source)
        {
            Random rnd = new Random( (int)DateTime.Now.Ticks & 0x0000FFFF );
            this.Name = source.Name + rnd.Next( 1000 );
            this.Settings = new NetSettings {
                Address = source.Settings.Address,
                Gateway = source.Settings.Gateway,
                InterfaceName = source.Settings.InterfaceName,
                IsStatic = source.Settings.IsStatic,
                NetMask = source.Settings.NetMask
            };
            if ( source.Settings.Nameservers != null ) {
                this.Settings.Nameservers = new List<string>(
                        source.Settings.Nameservers
                    );
            }
        }
    }
}
