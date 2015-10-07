using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataGenerator
{
    class Engine
    {
        private SessionParameters sessionParameters;
        private SpnLookup Lookup;
        private Timer timer;
        public Engine(SpnLookup lookup, SessionParameters p)
        {
            Lookup = lookup;
            sessionParameters = p;
            timer = new Timer(p.frequency.TotalMilliseconds);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var output=new Dictionary<int, String>();
            for (int i = 0; i < sessionParameters.numberToSpawn; i++)
            {
                var vehicleId = new Random().Next(1, sessionParameters.numberVehicles + 1);
                var spnNumber = new Random().Next(1, Lookup.SpnCount+1);

                var currentSpn = Lookup.Lookup.ToList()[spnNumber].Value;
               

                var value = GetValue(currentSpn);
                var time = DateTime.Now.ToString("MMDDyyyytttt");
                var string1 = string.Format("[ {0},{1},{2},{3} ]", time, vehicleId, currentSpn.SpnNumber, value.ToString());
                output.Add(currentSpn.SpnNumber, string1 );
            }
            WriteOutput(output);
        }


        private void WriteOutput(Dictionary<int, string> output)
        {
            foreach (var grup in output.GroupBy(x => x.Key))
            {
                var filename = String.Format("z_{0}_{1}_data.data", grup.Key, DateTime.Now.ToString("MMDDYYYYtttt"));
                StreamWriter FileWriter = new StreamWriter(filename);
                foreach (var i in grup)
                {
                   
                    FileWriter.Write(i.Value);
                }

                FileWriter.Close();
            }
        }

        private double GetValue(Spn spn)
        {
            int lowval = (int) (spn.Lowvalue*(int)(Math.Pow(10.0,(double)(spn.Factor))));
            int highval = (int) (spn.Highvalue*(int)(Math.Pow(10.0,(double)spn.Factor)));

            var ok = new Random().Next(lowval, highval);
            double okout = (double) ok/((double)Math.Pow(10.0,(double)spn.Factor));
            return okout;
        }

        public void Start()
        {
            timer.Start();
            



        }

        public void Stop()
        {
            timer.Stop();
        }

        public void ResetParameters(SessionParameters p)
        {
            sessionParameters = p;
        }

        public void ResetLookup(SpnLookup lookup)
        {
            Lookup = lookup;
        }
    }

    internal class SessionParameters
    {
        public TimeSpan frequency;
        public int numberVehicles;
        public int numberToSpawn;

        public SessionParameters(string[] args)
        {
            try
            {
                var inta = int.Parse(args[0]);
                frequency = TimeSpan.FromSeconds(inta);
                numberVehicles = int.Parse(args[1]);
                numberToSpawn = int.Parse(args[2]);
            }
            catch (Exception e)
            {
                
            }

        }
    }
}
