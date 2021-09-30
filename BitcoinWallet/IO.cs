using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace BitcoinWallet
{
    internal static class IO
    {
        public static void WriteToFile<T>(string filePath, ref T fileData)
        {
            string jsonString = JsonConvert.SerializeObject(fileData, Formatting.Indented);
            File.WriteAllText(filePath, jsonString, Encoding.UTF8);            
        }

        public static bool DoesFileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public static bool DoesDirectoryExist(string directory)
        {
            return System.IO.Directory.Exists(directory);
        }

        public static KeyManager ReadFromFile(string filePath)
        {
            return JsonConvert.DeserializeObject<KeyManager>(filePath);
        }
    }
}
