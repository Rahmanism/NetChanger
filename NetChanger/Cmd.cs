using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChanger
{
    /// <summary>
    /// It'll have some static methods to run commands (usually in cmd.exe).
    /// </summary>
    public class Cmd
    {
        /// <summary>
        /// Runs a sysctem command
        /// </summary>
        /// <param name="command"></param>
        public static void Execute(string command)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();
        }

        /// <summary>
        /// Runs multiple system commands
        /// </summary>
        public static void Execute(string[] commands)
        {
            foreach ( string command in commands ) {
                Execute( command );
            }
        }

    }
}
