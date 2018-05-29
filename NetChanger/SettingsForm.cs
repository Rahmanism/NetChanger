using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class SettingsForm : Form
    {
        public const string EDIT_CURRENT = "edit-current";
        public const string NEW = "new";

        private string action = EDIT_CURRENT;

        public SettingsForm(string act = NEW)
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
            //Program.operations.Net.Profile.Settings.InterfaceName = ifaceTxt.Text;
            //Program.operations.Net.Profile.Settings.Address = addressTxt.Text;
            //Program.operations.Net.Profile.Settings.NetMask = netmaskTxt.Text;
            //Program.operations.Net.Profile.Settings.Gateway = gatewayTxt.Text;
            //Program.operations.Net.Profile.Settings.Nameservers = nameserversLbx.Items.Cast<string>().ToList();
            //Program.operations.Net.Profile.Settings.IsStatic = staticRbn.Checked;

            if ( action == NEW ) {

            }
            else if ( action == EDIT_CURRENT ) {
                Program.operations.Net.Profile.Name = profileNameTxt.Text.Trim();
                Program.operations.Net.Profile.Settings.InterfaceName = ifaceTxt.Text.Trim();
                Program.operations.Net.Profile.Settings.IsStatic = staticRbn.Checked;
                Program.operations.Net.Profile.Settings.Nameservers = new List<string>();
                if ( nameserversLbx.Items.Count > 0 ) {
                    Program.operations.Net.Profile.Settings.Nameservers.AddRange( nameserversLbx.Items.Cast<string>() );
                }
                Program.operations.Net.Profile.Settings.Address = addressTxt.Text.Trim();
                Program.operations.Net.Profile.Settings.NetMask = netmaskTxt.Text.Trim();
                Program.operations.Net.Profile.Settings.Gateway = gatewayTxt.Text.Trim();

                Properties.Settings.Default.ActiveProfile = Program.operations.Net.Profile.Name;
                Properties.Settings.Default.Save();
            }

            // TODO: Change the profile, and save it to the json file.
            // TODO: check IPs to be valid using regex.

            // Closes the form.
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.MainIcon;
            if ( action == EDIT_CURRENT ) {
                FillSettingsControls();
            }
            else if ( action == NEW ) {
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
            profileNameTxt.Text = Program.operations.Net.Profile.Name;
            ifaceTxt.Text = Program.operations.Net.Profile.Settings.InterfaceName;
            addressTxt.Text = Program.operations.Net.Profile.Settings.Address;
            netmaskTxt.Text = Program.operations.Net.Profile.Settings.NetMask;
            gatewayTxt.Text = Program.operations.Net.Profile.Settings.Gateway;
            nameserversLbx.Items.Clear();
            if ( Program.operations.Net.Profile.Settings.Nameservers != null ) {
                nameserversLbx.Items.AddRange( Program.operations.Net.Profile.Settings.Nameservers?.ToArray() );
            }

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
            profileNameTxt.Text = aProfile.Name;
            ifaceTxt.Text = aProfile.Settings.InterfaceName;
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

        private void addNameserverBtn_Click(object sender, EventArgs e)
        {
            nameserversLbx.Items.Add( dnsTxt.Text.Trim() );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( nameserversLbx.SelectedItem != null ) {
                nameserversLbx.Items.Remove( nameserversLbx.SelectedItem );
            }
        }

        private void moveDnsUpBtn_Click(object sender, EventArgs e)
        {
            if ( nameserversLbx.SelectedItem == null || nameserversLbx.SelectedIndex < 1 )
                return;

            var temp = nameserversLbx.Items[nameserversLbx.SelectedIndex - 1];
            nameserversLbx.Items[nameserversLbx.SelectedIndex - 1] = nameserversLbx.SelectedItem;
            nameserversLbx.Items[nameserversLbx.SelectedIndex] = temp;
            nameserversLbx.SelectedIndex--;
        }

        private void moveDnsDownBtn_Click(object sender, EventArgs e)
        {
            if ( nameserversLbx.SelectedItem == null || nameserversLbx.SelectedIndex == nameserversLbx.Items.Count - 1 )
                return;

            var temp = nameserversLbx.SelectedItem;
            nameserversLbx.Items[nameserversLbx.SelectedIndex] = nameserversLbx.Items[nameserversLbx.SelectedIndex + 1];
            nameserversLbx.Items[nameserversLbx.SelectedIndex + 1] = temp;
            nameserversLbx.SelectedIndex++;
        }
    }
}
