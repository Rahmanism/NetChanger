using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;


namespace NetChanger
{
    /// <summary>
    /// Read and Write operations in Json format.
    /// </summary>
    class MyJson
    {
        /// <summary>
        /// Reads Json data from the given path (file), and deserialize it to the requested type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T ReadData<T>(string path) where T : new()
        {
            var jsonData = String.Empty;

            try {
                // Open the file              
                var stream = File.OpenText( path );
                // Read the file              
                jsonData = stream.ReadToEnd();
            }
            catch ( Exception ) { }
            // if string with JSON data is not empty, deserialize it to class and return its instance 
            return !string.IsNullOrEmpty( jsonData ) ? JsonSerializer.Deserialize<T>( jsonData ) : new T();
        }

        /// <summary>
        /// Write data to json file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void WriteData<T>(string path, T data) where T : new ()
        {
            var jsonData = JsonSerializer.Serialize(data);

            try {
                File.WriteAllText( path, jsonData );
            }
            catch ( Exception x) {
                MessageBox.Show( x.Message );
            }
        }
    }
}
