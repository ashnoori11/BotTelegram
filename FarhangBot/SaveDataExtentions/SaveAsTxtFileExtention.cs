using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangBot.SaveDataExtentions
{
    public static class SaveAsTxtFileExtention
    {
        public static void WriteAsync(string text)
        {
            string rootPath = Path.GetPathRoot(Environment.SystemDirectory);
            string path = $"{rootPath}{ @"temp\BotInfo.txt"}";

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                 StreamWriter file = new StreamWriter(path, append: true);
                 file.WriteLineAsync(text);
                file.Close();
            }
        }

        public static void WriteAnswers(string text)
        {
            string rootPath = Path.GetPathRoot(Environment.SystemDirectory);
            string path = $"{rootPath}{ @"temp\BotInfo.txt"}";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                StreamWriter file = new StreamWriter(path, append: true);
                file.WriteLineAsync(text);
                file.Close();
            }
        }
    }
}
