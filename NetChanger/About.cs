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
                GetCustomAttribute( typeof( AssemblyDescriptionAttribute ) ) ).Description +
                "\n" +
                Resources.Resources.slogan;

            // show the app attributes (i.e version and etc.) in the form
            versionLbl.Text = "v" + ver;
            titleLbl.Text = title;
            okBtn.Text = Resources.Resources.ok;
            this.Text = Resources.Resources.about;
            descriptionLbl.Text = description;
            string releaseDate = "1397/03/14";
            dateLbl.Text = $"{Resources.Resources.release_date_of_this_version}: {releaseDate}";
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void myNameLlb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start( "http://rahmanism.ir" );
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start( "https://gitlab.com/Rahmanism/NetChanger" );
        }
    }
}
