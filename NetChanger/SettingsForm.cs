using System;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            // Change the current settings (just) values
            Program.operations.Net.InterfaceName = ifaceTxt.Text;
            Program.operations.Net.Address = addressTxt.Text;
            Program.operations.Net.NetMask = netmaskTxt.Text;
            Program.operations.Net.Gateway = gatewayTxt.Text;
            Program.operations.Net.DnsOne = dns1Txt.Text;
            Program.operations.Net.DnsTwo = dns2Txt.Text;

            Program.operations.Net.Static = staticRbn.Checked;

            // TODO: this should not execute, but just save the settings
            // settings.save!!();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.MainIcon;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
