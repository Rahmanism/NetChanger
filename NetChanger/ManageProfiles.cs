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

        private void profilesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = profilesLbx.SelectedValue;
        }
    }
}
