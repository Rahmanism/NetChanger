using System.Collections.Generic;

namespace NetChanger
{
    class NetSettings
    {
        public bool IsStatic { get; set; } = false;
        public string InterfaceName;
        public string Address;
        public string NetMask;
        public string Gateway;
        public List<string> Nameservers { get; set; }
    }
}
