using System;
using System.Reflection;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void FormInit()
        {
            // load form icon
            Icon = Properties.Resources.MainIcon;

            // read app attributes
            string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string title = ( (AssemblyTitleAttribute)Assembly.GetExecutingAssembly()
                .GetCustomAttribute( typeof( AssemblyTitleAttribute ) ) ).Title;
            string description = ( (AssemblyDescriptionAttribute)Assembly.GetExecutingAssembly().
                GetCustomAttribute( typeof( AssemblyDescriptionAttribute ) ) ).Description;

            // show the app attributes (i.e version and etc.) in the form
            versionLbl.Text = "v" + ver;
            titleLbl.Text = title;
            descriptionLbl.Text = description;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void myNameLlb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start( "http://rahmanism.ir" );
        }
    }
}
