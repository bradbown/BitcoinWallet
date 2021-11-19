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
            string jsonString;

            try
            {
                jsonString = JsonConvert.SerializeObject(fileData, Formatting.Indented);
                File.WriteAllText(filePath, jsonString, Encoding.UTF8);
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }         
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
            string jsonFromFile;
            using (var reader = new StreamReader(filePath))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<KeyManager>(jsonFromFile);
        }

        public static List<KeyManager> ReadListFromFile(string filePath)
        {
            string jsonFromFile;
            using (var reader = new StreamReader(filePath))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<KeyManager>>(jsonFromFile);
        }
    }
}
