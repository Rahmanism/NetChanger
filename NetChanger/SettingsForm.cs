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
        private List<string> interfaces = new List<string>();

        public SettingsForm(string act = NEW)
        {
            action = act;
            InitializeComponent();
            LoadTexts();
        }

        public SettingsForm()
        {
            InitializeComponent();
            LoadTexts();
        }

        private void LoadTexts()
        {
            this.Text = Resources.Resources.ip_settings;
            nameLbl.Text = Resources.Resources.profile_name;
            ipGbx.Text = Resources.Resources.ip_settings;
            staticRbn.Text = Resources.Resources.static_;
            dhcpRbn.Text = Resources.Resources.dhcp;
            ifaceLbl.Text = Resources.Resources.interface_name;
            addressLbl.Text = Resources.Resources.address;
            netmaskLbl.Text = Resources.Resources.netmask;
            gatewayLbl.Text = Resources.Resources.gateway;
            nameserversLbl.Text = Resources.Resources.nameservers;
            moveDnsUpBtn.Text = Resources.Resources.up;
            moveDnsDownBtn.Text = Resources.Resources.down;
            cancelBtn.Text = Resources.Resources.cancel;
            okBtn.Text = Resources.Resources.ok;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            bool updateSuccessful = false;
            if (action == NEW) {
                var newProfile = new Profile();
                updateSuccessful = UpdateProfile(newProfile);
                if (updateSuccessful) {
                    Program.operations.Profiles.Add(newProfile);
                }
            }
            else if (action == EDIT_CURRENT) {
                updateSuccessful = UpdateProfile(Program.operations.Net.Profile);
                if (updateSuccessful) {
                    // save the active profile.
                    Properties.Settings.Default.ActiveProfile = Program.operations.Net.Profile.Name;
                    Properties.Settings.Default.Save();
                }
            }
            else { // edit a specific profile mode
                var profile = Program.operations.FindProfile(this.action);
                updateSuccessful = UpdateProfile(profile);
            }

            if (updateSuccessful) {
                // save data to the file, and update menu.
                Program.operations.UpdateProfilesFull();

                // Closes the form.
                Close();
            }
        }

        /// <summary>
        /// Saves the data from form to the given profile.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>True if no exception happend, false otherwise.</returns>
        private bool UpdateProfile(Profile profile)
        {
            try {
                profile.Name = profileNameTxt.Text.Trim();
                profile.Settings = new NetSettings {
                    InterfaceName = ifaceCbx.Text.Trim(),
                    IsStatic = staticRbn.Checked,
                    Address = addressTxt.Text.Trim(),
                    NetMask = netmaskTxt.Text.Trim(),
                    Gateway = gatewayTxt.Text.Trim(),
                    Nameservers = null
                };
                if (nameserversLbx.Items.Count > 0) {
                    profile.Settings.Nameservers = new List<string>();
                    profile.Settings.Nameservers.AddRange(nameserversLbx.Items.Cast<string>());
                }

                return true;
            }
            catch (Exception x) {
                MessageBox.Show(x.Message, Resources.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.MainIcon;
            LoadInterfaces();
            if (action == EDIT_CURRENT) {
                FillSettingsControls();
            }
            else if (action == NEW) {
                FillWithEmpty();
            }
            else {
                FillWithProfile(action);
            }
        }

        private void LoadInterfaces()
        {
            interfaces = new List<string>();
            string ids = Cmd.Execute(new string[] { Program.operations.Net.NetConnectionIDs })[0];
            var idsArray = new List<string>(ids.Split(new char[] { '\r', '\r', '\n' }));
            idsArray.RemoveAt(0);
            interfaces.AddRange(idsArray.Where(i => i.Trim().Length > 0).Select(t => t.Trim()));
            ifaceCbx.Items.Clear();
            ifaceCbx.Items.AddRange(interfaces.ToArray());
        }

        /// <summary>
        /// Empties the form controls (usually for creating new profile)
        /// </summary>
        private void FillWithEmpty()
        {
            profilesCbx.Text = "new profile";
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
            ifaceCbx.Text = Program.operations.Net.Profile.Settings.InterfaceName;
            addressTxt.Text = Program.operations.Net.Profile.Settings.Address;
            netmaskTxt.Text = Program.operations.Net.Profile.Settings.NetMask;
            gatewayTxt.Text = Program.operations.Net.Profile.Settings.Gateway;
            nameserversLbx.Items.Clear();
            if (Program.operations.Net.Profile.Settings.Nameservers != null) {
                nameserversLbx.Items.AddRange(Program.operations.Net.Profile.Settings.Nameservers?.ToArray());
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
            var aProfile = Program.operations.FindProfile(profileName);
            profileNameTxt.Text = aProfile.Name;
            ifaceCbx.Text = aProfile.Settings.InterfaceName;
            addressTxt.Text = aProfile.Settings.Address;
            netmaskTxt.Text = aProfile.Settings.NetMask;
            gatewayTxt.Text = aProfile.Settings.Gateway;
            nameserversLbx.Items.Clear();
            if (aProfile.Settings.Nameservers != null) {
                nameserversLbx.Items.AddRange(aProfile.Settings.Nameservers.ToArray());
            }

            staticRbn.Checked = aProfile.Settings.IsStatic;
            dhcpRbn.Checked = !staticRbn.Checked;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNameserverBtn_Click(object sender, EventArgs e)
        {
            nameserversLbx.Items.Add(dnsTxt.Text.Trim());
        }

        private void removeNameServerBtn_Click(object sender, EventArgs e)
        {
            if (nameserversLbx.SelectedItem != null) {
                nameserversLbx.Items.Remove(nameserversLbx.SelectedItem);
            }
        }

        private void moveDnsUpBtn_Click(object sender, EventArgs e)
        {
            if (nameserversLbx.SelectedItem == null || nameserversLbx.SelectedIndex < 1)
                return;

            var temp = nameserversLbx.Items[nameserversLbx.SelectedIndex - 1];
            nameserversLbx.Items[nameserversLbx.SelectedIndex - 1] = nameserversLbx.SelectedItem;
            nameserversLbx.Items[nameserversLbx.SelectedIndex] = temp;
            nameserversLbx.SelectedIndex--;
        }

        private void moveDnsDownBtn_Click(object sender, EventArgs e)
        {
            if (nameserversLbx.SelectedItem == null || nameserversLbx.SelectedIndex == nameserversLbx.Items.Count - 1)
                return;

            var temp = nameserversLbx.SelectedItem;
            nameserversLbx.Items[nameserversLbx.SelectedIndex] = nameserversLbx.Items[nameserversLbx.SelectedIndex + 1];
            nameserversLbx.Items[nameserversLbx.SelectedIndex + 1] = temp;
            nameserversLbx.SelectedIndex++;
        }
    }
}
