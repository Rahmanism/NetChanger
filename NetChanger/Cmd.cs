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
        public static string Execute(string command)
        {
            // create the ProcessStartInfo using "cmd" as the program to be run,
            // and "/c " as the parameters.
            // Incidentally, /c tells cmd that we want it to execute the command
            // that follows, and then exit.
            var procStartInfo =
                new ProcessStartInfo( "cmd", "/c " + command ) {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
            var proc = new Process() {
                StartInfo = procStartInfo
            };
            proc.Start();

            // Get the output into a string
            string result = proc.StandardOutput.ReadToEnd();

            return result;
        }

        /// <summary>
        /// Runs multiple system commands
        /// </summary>
        public static string[] Execute(string[] commands)
        {
            var results = new string[commands.Length];
            for (var i = 0; i < commands.Length; i++ ) {
                results[i] = Execute( commands[i] );
            }

            return results;
        }
    }
}
