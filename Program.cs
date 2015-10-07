using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile();

        }

        private static SpnLookup ReadFile()
        {


            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "DataGenerator.1939_sig_data.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    StreamReader FileReader = new StreamReader(stream);
                    string header;
                    List<String> lines = new List<string>();
                    header = FileReader.ReadLine();
                    while (!FileReader.EndOfStream)
                    {
                        lines.Add(FileReader.ReadLine().Trim());
                    }
                    FileReader.Close();



                    var spnlookup = new SpnLookup(header, lines);
                    return spnlookup;
                }
                return null;
            }


        }
    }
}
