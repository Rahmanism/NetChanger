using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );

            operations = new Operations();

            Application.Run();
        }
    }
}
