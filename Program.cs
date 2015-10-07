using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataGenerator
{
    class Program
    {
        private static Engine engine;

        /// <summary>
        /// main method
        /// </summary>
        static void Main(string[] args)
        {
            var loookup = ReadFile();
            var sp = new SessionParameters(args);
            engine = new Engine(loookup, sp);
            RunEngine();
        }

        /// <summary>
        /// starts engine
        /// listens for user input
        /// </summary>
        private static void RunEngine()
        {
            engine.Start();
            Write("running...press Q to quit, or P to pause");
            var info = Console.ReadKey(true).Key;
            GoNext(info);
        }

        /// <summary>
        /// directs flow
        /// </summary>
        private static void GoNext(ConsoleKey info)
        {
            switch (info)
            {
                case ConsoleKey.Q:
                    return;
                case ConsoleKey.P:
                    Pause();
                    break;
                default:
                    info = Console.ReadKey(true).Key;
                    GoNext(info);
                    break;
            }
           
        }

        /// <summary>
        /// pauses engine
        /// </summary>
        private static void Pause()
        {
            engine.Stop();
            Write("press any key to continue");
            Console.ReadKey(true);
            RunEngine();
        }


        /// <summary>
        /// reads file into memory
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// writes stuff
        /// </summary>
        /// <param name="r"></param>
        private static void Write(string r)
        {
            Console.WriteLine(r);
        }
    }
}
