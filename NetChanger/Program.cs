using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace NetChanger
{
    static class Program
    {
        public static CultureInfo CulInfo;
        public static Operations operations;

        // TODO: use resource for languages in all texts.

        public static void SwitchLanguage(string lang = null)
        {
            if (lang == null)
                lang = Properties.Settings.Default.Language;
            CulInfo = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = CulInfo;
            Thread.CurrentThread.CurrentUICulture = CulInfo;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Load language based on app settings.
            SwitchLanguage();

            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new(wi);

            bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);

            if (!runAsAdmin) {
                // It is not possible to launch a ClickOnce app as administrator directly,
                // so instead we launch the app as administrator in a new process.
                var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase) {

                    // The following properties run the new process as administrator
                    UseShellExecute = true,
                    Verb = "runas"
                };

                // Start the new process
                try {
                    Process.Start(processInfo);
                }
                catch (Exception) {
                    // The user did not allow the application to run as administrator
                    MessageBox.Show(
                        Resources.Resources.admin_rights_needed, // ResManager.GetString( "admin_rights_needed" ),
                        Resources.Resources.netchagner, // ResManager.GetString( "netchanger" ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                }

                // Shut down the current process
                Application.Exit();
            }
            else {
                // We are running as administrator
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                operations = new Operations();

                Application.Run();
            }
        }
    }
}
