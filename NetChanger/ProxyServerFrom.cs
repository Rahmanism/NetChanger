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
    public partial class ProxyServerFrom : Form
    {
        ProxySettings _proxy;

        public ProxyServerFrom(ProxySettings proxy)
        {
            _proxy = proxy;
            InitializeComponent();
            LoadTexts();
            LoadServer();
        }

        /// <summary>
        /// Load control texts from resources.
        /// </summary>
        private void LoadTexts()
        {
            this.Text = Resources.Resources.proxy_server;
            ipLbl.Text = Resources.Resources.proxy_ip_address;
            portLbl.Text = Resources.Resources.proxy_port;
            saveBtn.Text = Resources.Resources.save;
            cancelBtn.Text = Resources.Resources.cancel;
        }

        /// <summary>
        /// Load current override addresses into the text input.
        /// </summary>
        private void LoadServer()
        {
            string[] server = _proxy.GetProxyServer();
            ipTxt.Text = server[0];
            portTxt.Text = server[1];
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var log = new string[1];
            try {
                _proxy.ChangeProxyServer(ipTxt.Text, portTxt.Text);
                log[0] = "Proxy address changed.";
            }
            catch (Exception ex) {
                log[0] = ex.Message;
            }

            Program.operations.Log(log);
            Close();
        }
    }
}
