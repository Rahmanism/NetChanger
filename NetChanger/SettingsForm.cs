using System;
using System.Collections.Generic;
using System.Linq;
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
            // Change the current settings
            Program.operations.Net.Profile.Settings.InterfaceName = ifaceTxt.Text;
            Program.operations.Net.Profile.Settings.Address = addressTxt.Text;
            Program.operations.Net.Profile.Settings.NetMask = netmaskTxt.Text;
            Program.operations.Net.Profile.Settings.Gateway = gatewayTxt.Text;
            Program.operations.Net.Profile.Settings.Nameservers = nameserversLbx.Items.Cast<string>().ToList();
            Program.operations.Net.Profile.Settings.IsStatic = staticRbn.Checked;

            // TODO: save the changes in json file

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
            else {
                FillWithProfile( action );
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

            staticRbn.Checked = false;
            dhcpRbn.Checked = !staticRbn.Checked;
        }

        /// <summary>
        /// Fill the form with read data for current profile.
        /// </summary>
        private void FillSettingsControls()
        {
            // fill the controls (text boxes and ...) in the form based on read data.
            ifaceTxt.Text = Program.operations.Net.Profile.Settings.InterfaceName;
            addressTxt.Text = Program.operations.Net.Profile.Settings.Address;
            netmaskTxt.Text = Program.operations.Net.Profile.Settings.NetMask;
            gatewayTxt.Text = Program.operations.Net.Profile.Settings.Gateway;
            nameserversLbx.Items.Clear();
            nameserversLbx.Items.AddRange( Program.operations.Net.Profile.Settings.Nameservers.ToArray() );

            staticRbn.Checked = Program.operations.Net.Profile.Settings.IsStatic;
            dhcpRbn.Checked = !staticRbn.Checked;
        }

        /// <summary>
        /// Fill the form with read data for a specific profile
        /// </summary>
        private void FillWithProfile(string profileName)
        {
            // fill the controls (text boxes and ...) in the form based on read data.
            var aProfile = Program.operations.Profiles.Find(
                    p => p.Name.ToLower().Equals( profileName )
                );
            ifaceTxt.Text =   aProfile.Settings.InterfaceName;
            addressTxt.Text = aProfile.Settings.Address;
            netmaskTxt.Text = aProfile.Settings.NetMask;
            gatewayTxt.Text = aProfile.Settings.Gateway;
            nameserversLbx.Items.Clear();
            nameserversLbx.Items.AddRange( aProfile.Settings.Nameservers.ToArray() );

            staticRbn.Checked = aProfile.Settings.IsStatic;
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
