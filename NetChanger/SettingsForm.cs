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

            Properties.Settings.Default["NetProperties"] = Program.operations.Net;
            Properties.Settings.Default.Save();


            // Closes the form.
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.MainIcon;
            FillSettingsControls();
        }

        private void FillSettingsControls()
        {
            var net = Program.operations.Net;

            // fill the controls (text boxes and ...) in the form based on read data.
            ifaceTxt.Text = net.InterfaceName;
            addressTxt.Text = net.Address;
            netmaskTxt.Text = net.NetMask;
            gatewayTxt.Text = net.Gateway;
            dns1Txt.Text = net.DnsOne;
            dns2Txt.Text = net.DnsTwo;

            staticRbn.Checked = net.Static;
            dhcpRbn.Checked = !staticRbn.Checked;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
