using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rahmanism.ir
{
    /// <summary>
    /// Some methods that useful in other apps and
    /// they're not specific to this app
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Add/Remove registry entries for windows startup.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        /// <param name="appPath">The application's executable path, if not set, the current app itself will be assumed.</param>
        public static void SetStartup(string appName, bool enable, string appPath = "")
        {
            appPath = ( string.IsNullOrEmpty( appPath.Trim() ) ) ? Application.ExecutablePath : appPath;
            const string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            var startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey( runKey );

            if ( enable ) {
                if ( startupKey.GetValue( appName ) == null ) {
                    startupKey.Close();
                    startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey( runKey, true );
                    // Add startup reg key
                    startupKey.SetValue( appName, appPath );
                    startupKey.Close();
                }
            }
            else {
                // remove startup
                startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey( runKey, true );
                startupKey.DeleteValue( appName, false );
                startupKey.Close();
            }
        }

        /// <summary>
        /// Create a shortcut of the given app to a target (or Desktop)
        /// </summary>
        /// <param name="shortcutName">The that will be appear on shortcut</param>
        /// <param name="appPath">The path of the application you want make a shortcut of it.</param>
        /// <param name="where">Where to put the shortcut, if you don't pass it, the default is Desktop</param>
        public static void CreateShortcut(string shortcutName, string appPath, string where = "")
        {
            // Windows Script Host Shell Object
            Type t = Type.GetTypeFromCLSID( new Guid( "72C24DD5-D70A-438B-8A42-98424B88AFB8" ) );
            // If where was null then put the shortcut to Desktop
            where = ( where.Trim() == "" ) ?
                Environment.GetFolderPath( Environment.SpecialFolder.Desktop ) : where;
            dynamic shell = Activator.CreateInstance( t );
            try {
                var lnk = shell.CreateShortcut( where + "\\" + shortcutName + ".lnk" );
                try {
                    lnk.TargetPath = appPath;
                    lnk.WorkingDirectory = Path.GetDirectoryName( appPath );
                    //lnk.IconLocation = "shell32.dll, 1";
                    lnk.Save();
                }
                finally {
                    Marshal.FinalReleaseComObject( lnk );
                }
            }
            finally {
                Marshal.FinalReleaseComObject( shell );
            }
        }

        /// <summary>
        /// Create shortcut of current app with it's product name in Desktop
        /// </summary>
        public static void CreateShortcut()
        {
            CreateShortcut( Application.ProductName, Application.ExecutablePath );
        }

        /// <summary>
        /// Adds shortcut of app to the startup folder (not registry)
        /// </summary>
        /// <param name="appPath">The application (that should be in startup) path,
        /// if it's null the default is the path of current application
        /// </param>
        public static void PutInStartupFolder(string appPath = "")
        {
            appPath = ( appPath.Trim() == "" ) ? Application.ExecutablePath : appPath;
            string startupFolder = Environment.GetFolderPath( Environment.SpecialFolder.Startup );
            CreateShortcut( Application.ProductName, Application.ExecutablePath, startupFolder );
        }
    }
}
