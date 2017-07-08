using System;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
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

        private void mainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.MainIcon;
        }
    }
}
