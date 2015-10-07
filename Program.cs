using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            
        }

        private static SpnLookup ReadFile(string filename)
        {
            StreamReader FileReader = new StreamReader(@"C:\MyFile.txt");
            string FileContents;
            FileContents = FileReader.ReadToEnd();
            FileReader.Close();
           /* foreach (string s in strValuesToSearch)
            {
                if (FileContents.Contains(s))
                    FileContents = FileContents.Replace(s, stringToReplace);
            }*/



            StreamWriter FileWriter = new StreamWriter(@"MyFile.txt");
            FileWriter.Write(FileContents);
            FileWriter.Close();




        }
    }
}
