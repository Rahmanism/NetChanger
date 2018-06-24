using System;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class ManageProfiles : Form
    {
        public ManageProfiles()
        {
            InitializeComponent();
            Icon = Properties.Resources.MainIcon;
            LoadTexts();
        }

        private void LoadTexts()
        {
            this.Text = Resources.Resources.manage_profiles;
            listTitleLbl.Text = Resources.Resources.profiles_list;
            newBtn.Text = Resources.Resources.new_;
            editBtn.Text = Resources.Resources.edit;
            deleteBtn.Text = Resources.Resources.delete;
            duplicateBtn.Text = Resources.Resources.duplicate;
            closeBtn.Text = Resources.Resources.close;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var editProfile = new SettingsForm( profilesLbx.SelectedItem.ToString() );
            editProfile.Show();
        }

        private void ReloadProfilesList()
        {
            profilesLbx.Items.Clear();
            foreach ( var item in Program.operations.Profiles ) {
                profilesLbx.Items.Add( item.Name );
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if ( profilesLbx.SelectedItem != null ) {
                string selectedItem = profilesLbx.SelectedItem.ToString();
                if ( MessageBox.Show( "Are you sure to delete this item ?? It cannot be undone.",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo ) == DialogResult.Yes ) {
                    var profileToDelete = Program.operations.Profiles.Find(
                        p => p.Name.ToLower().Equals( selectedItem ) );
                    Program.operations.Profiles.Remove( profileToDelete );
                    Program.operations.UpdateProfilesFull();
                    ReloadProfilesList();
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            var createProfile = new SettingsForm( SettingsForm.NEW );
            createProfile.Show();
        }

        private void duplicateBtn_Click(object sender, EventArgs e)
        {
            try {
                var source = profilesLbx.SelectedItem.ToString();
                Program.operations.Duplicate( source );
                Program.operations.UpdateProfilesFull();
                ReloadProfilesList();
                profilesLbx.SelectedIndex = profilesLbx.FindString( source );
            }
            catch (Exception x) {
                MessageBox.Show( x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void ManageProfiles_Activated(object sender, EventArgs e)
        {
            ReloadProfilesList();
        }
    }
}
