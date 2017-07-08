using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            var net = new NetProperties {
                InterfaceName = ifaceTxt.Text,
                Address = addressTxt.Text,
                NetMask = netmaskTxt.Text,
                Gateway = gatewayTxt.Text,
                DnsOne = dns1Txt.Text,
                DnsTwo = dns2Txt.Text,
                Static = staticRbn.Checked
            };

            Cmd.Execute( net.Do );
        }
    }
}
