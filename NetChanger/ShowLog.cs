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
    public partial class ShowLog : Form
    {
        public ShowLog()
        {
            InitializeComponent();
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
