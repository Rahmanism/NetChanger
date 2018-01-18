using System;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class SettingsForm : Form
    {
        private string action = "edit-current";

        public SettingsForm(string act)
        {
            action = act;
            InitializeComponent();
        }

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

            // Setting values of net properties in app settings.
            Properties.Settings.Default.Address = Program.operations.Net.Address;
            Properties.Settings.Default.Netmask = Program.operations.Net.NetMask;
            Properties.Settings.Default.Gateway = Program.operations.Net.Gateway;
            Properties.Settings.Default.DnsOne = Program.operations.Net.DnsOne;
            Properties.Settings.Default.DnsTwo = Program.operations.Net.DnsTwo;
            Properties.Settings.Default.Static = Program.operations.Net.Static;
            Properties.Settings.Default.InterfaceName = Program.operations.Net.InterfaceName;

            // save the app settings.
            Properties.Settings.Default.Save();

            // Closes the form.
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.MainIcon;
            if ( action == "edit-current" ) {
                FillSettingsControls();
            } else if(action == "new") {
                FillWithEmpty();
            }
        }

        /// <summary>
        /// Empties the form controls (usually for creating new profile)
        /// </summary>
        private void FillWithEmpty()
        {
            ifaceTxt.Text = "";
            addressTxt.Text = "";
            netmaskTxt.Text = "";
            gatewayTxt.Text = "";
            dns1Txt.Text = "";
            dns2Txt.Text = "";

            staticRbn.Checked = false;
            dhcpRbn.Checked = !staticRbn.Checked;
        }

        /// <summary>
        /// Fill the form with read data.
        /// </summary>
        private void FillSettingsControls()
        {
            // fill the controls (text boxes and ...) in the form based on read data.
            ifaceTxt.Text = Program.operations.Net.InterfaceName;
            addressTxt.Text = Program.operations.Net.Address;
            netmaskTxt.Text = Program.operations.Net.NetMask;
            gatewayTxt.Text = Program.operations.Net.Gateway;
            dns1Txt.Text = Program.operations.Net.DnsOne;
            dns2Txt.Text = Program.operations.Net.DnsTwo;

            staticRbn.Checked = Program.operations.Net.Static;
            dhcpRbn.Checked = !staticRbn.Checked;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
