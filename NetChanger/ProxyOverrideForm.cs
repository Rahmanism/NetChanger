using System;
using System.Windows.Forms;

namespace NetChanger
{
    public partial class ProxyOverrideForm : Form
    {
        private ProxySettings _proxy;

        public ProxyOverrideForm(ProxySettings proxy)
        {
            _proxy = proxy;
            InitializeComponent();
            LoadTexts();
            LoadAddresses();
        }

        /// <summary>
        /// Load current override addresses into the text input.
        /// </summary>
        private void LoadAddresses()
        {
            addressesTxt.Text = _proxy.GetProxyOverride();
        }

        /// <summary>
        /// Load control texts from resources.
        /// </summary>
        private void LoadTexts()
        {
            this.Text = Resources.Resources.proxy_override;
            addressesLbl.Text = Resources.Resources.address;
            addressesCommentLbl.Text = Resources.Resources.proxy_override_addresses_comment;
            saveBtn.Text = Resources.Resources.save;
            cancelBtn.Text = Resources.Resources.cancel;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var log = new string[1];
            try {
                _proxy.ChangeProxyOverride(addressesTxt.Text);
                log[0] = "Proxy override addresses changed.";
            }
            catch (Exception ex) {
                log[0] = ex.Message;
            }

            Program.operations.Log(log);
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
