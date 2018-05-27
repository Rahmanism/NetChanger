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
            Program.operations.Net.Profile.Settings.InterfaceName = ifaceTxt.Text;
            Program.operations.Net.Profile.Settings.Address = addressTxt.Text;
            Program.operations.Net.Profile.Settings.NetMask = netmaskTxt.Text;
            Program.operations.Net.Profile.Settings.Gateway = gatewayTxt.Text;
            Program.operations.Net.Profile.Settings.Nameservers[0] = dns1Txt.Text;
            Program.operations.Net.Profile.Settings.Nameservers[1] = dns2Txt.Text;
            Program.operations.Net.Profile.Settings.IsStatic = staticRbn.Checked;

            // Setting values of net properties in app settings.
            Properties.Settings.Default.Address = Program.operations.Net.Profile.Settings.Address;
            Properties.Settings.Default.Netmask = Program.operations.Net.Profile.Settings.NetMask;
            Properties.Settings.Default.Gateway = Program.operations.Net.Profile.Settings.Gateway;
            Properties.Settings.Default.DnsOne =  Program.operations.Net.Profile.Settings.Nameservers[0];
            Properties.Settings.Default.DnsTwo =  Program.operations.Net.Profile.Settings.Nameservers[1];
            Properties.Settings.Default.Static =  Program.operations.Net.Profile.Settings.IsStatic;
            Properties.Settings.Default.InterfaceName = Program.operations.Net.Profile.Settings.InterfaceName;

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
            profilesCbx.Text = "new profile";
            ifaceTxt.Text = "";
            addressTxt.Text = "";
            netmaskTxt.Text = "";
            gatewayTxt.Text = "";
            nameserversLbx.Items.Clear();
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
            ifaceTxt.Text =   Program.operations.Net.Profile.Settings.InterfaceName;
            addressTxt.Text = Program.operations.Net.Profile.Settings.Address;
            netmaskTxt.Text = Program.operations.Net.Profile.Settings.NetMask;
            gatewayTxt.Text = Program.operations.Net.Profile.Settings.Gateway;
            dns1Txt.Text =    Program.operations.Net.Profile.Settings.Nameservers[0];
            dns2Txt.Text =    Program.operations.Net.Profile.Settings.Nameservers[1];
            // TODO: fill the nameservers listbox.

            staticRbn.Checked = Program.operations.Net.Profile.Settings.IsStatic;
            dhcpRbn.Checked = !staticRbn.Checked;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void profilesCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: load settings of the selected profile from json file.
        }
    }
}
