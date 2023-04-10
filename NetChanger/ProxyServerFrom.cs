using System;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class ProxyServerFrom : Form
    {
        readonly ProxySettings _proxy;

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
            defaultValueBtn.Text = Resources.Resources.default1;
        }

        /// <summary>
        /// Load current override addresses into the text input.
        /// </summary>
        private void LoadServer()
        {
            (string Server, string Port) = _proxy.GetProxyServer();
            if (Server != null) {
                ipTxt.Text = Server;
                portTxt.Text = Port;
            }
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

        private void defaultValueBtn_Click(object sender, EventArgs e)
        {
            ipTxt.Text = "127.0.0.1";
            portTxt.Text = "1080";
        }
    }
}
