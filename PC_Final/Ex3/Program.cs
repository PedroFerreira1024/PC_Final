using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex3
{
    public class Program
    {

        private const int BUFFER_SIZE = 1024;

        private static void searchAndListFiles(String rootPath, String extension, String toLookFor)
        {
            DirectoryInfo root = new DirectoryInfo(rootPath);

            foreach(var dir in root.EnumerateDirectories())
            {
                Task.Factory.StartNew(() =>
                {
                    searchAndListFiles(dir.Name, extension, toLookFor);
                });
            }

            foreach(var file in root.EnumerateFiles())
            {
                if(file.Extension.Equals(extension))
                {
                    Task.Factory.StartNew(() =>
                    {
                        using (FileStream stream = file.OpenRead())
                        {
                            byte[] buff = new byte[file.Length];
                            UTF8Encoding temp = new UTF8Encoding(true);
                            while (stream.Read(buff, 0, buff.Length) > 0)
                            {
                                if (buff.ToString().Contains("tolookFor"))
                                    return;//==
                            }
                        }
                    });
                }
            }
        }

        public void checkIfContainsWord(object state)
        {
            
        }


        public static void Main(string[] args)
        {
            searchAndListFiles(@"",".rtf","");

        }
    }
}
