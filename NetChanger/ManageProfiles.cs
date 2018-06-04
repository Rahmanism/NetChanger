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
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var editProfile = new SettingsForm( profilesLbx.SelectedItem.ToString() );
            editProfile.Show();
        }

        private void ManageProfiles_Load(object sender, EventArgs e)
        {
            ReloadProfilesList();
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
            if ( MessageBox.Show( "Are you sure to delete this item ?? It cannot be undone.",
                                  "Confirm Delete!!",
                                  MessageBoxButtons.YesNo ) == DialogResult.Yes ) {
                var profileToDelete = Program.operations.Profiles.Find(
                    p => p.Name.ToLower().Equals( profilesLbx.SelectedItem.ToString() ) );
                Program.operations.Profiles.Remove( profileToDelete );
                Program.operations.UpdateProfilesFull();
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
    }
}
