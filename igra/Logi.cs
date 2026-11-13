using System;
using System.IO;

namespace Igra.Logging 
{
    public class Logi
    {
        public StreamWriter writer;

        public Logi(string path)
        {
            writer = new StreamWriter(path, append: true);
        }

        public void Log(string text)
        {
            writer.WriteLine(text);
            Console.WriteLine(text);
        }

        public void Close()
        {
            writer.Close();
        }
    }
}