using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace NetChanger
{
    static class Program
    {
        public static Operations operations;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal( wi );

            bool runAsAdmin = wp.IsInRole( WindowsBuiltInRole.Administrator );

            if ( !runAsAdmin ) {
                // It is not possible to launch a ClickOnce app as administrator directly,
                // so instead we launch the app as administrator in a new process.
                var processInfo = new ProcessStartInfo( Assembly.GetExecutingAssembly().CodeBase ) {

                    // The following properties run the new process as administrator
                    UseShellExecute = true,
                    Verb = "runas"
                };

                // Start the new process
                try {
                    Process.Start( processInfo );
                }
                catch ( Exception ) {
                    // The user did not allow the application to run as administrator
                    MessageBox.Show( "Sorry, but I don't seem to be able to start " +
                       "this program with administrator rights!" );
                }

                // Shut down the current process
                Application.Exit();
            }
            else {
                // We are running as administrator
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );

                operations = new Operations();

                Application.Run();
            }
        }
    }
}
