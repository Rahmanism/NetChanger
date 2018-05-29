using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            profilesLbx.Items.Clear();
            foreach ( var item in Program.operations.Profiles ) {
                profilesLbx.Items.Add( item.Name );
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // TODO: delete a profile and save the result in the json file.
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
