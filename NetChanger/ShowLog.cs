using System;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class ShowLog : Form
    {
        public ShowLog()
        {
            InitializeComponent();
            LoadTexts();
        }

        private void LoadTexts()
        {
            this.Text = Resources.Resources.show_log;
            logTitleLbl.Text = Resources.Resources.log_of_command_results;
            closeBtn.Text = Resources.Resources.close;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowLog_Load(object sender, EventArgs e)
        {
            logLbx.Items.Clear();
            logLbx.Items.AddRange( Program.operations.ResultsLog.ToArray() );
        }
    }
}
