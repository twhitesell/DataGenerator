using System;

namespace DataGenerator
{
    internal class SessionParameters
    {
        public TimeSpan Frequency { get; set; }
        public int NumberVehicles { get; set; }
        public int NumberToSpawn { get; set; }

        public SessionParameters(string[] args)
        {
            try
            {
                var secondsbetweengenerations = int.Parse(args[0]);
                Frequency = TimeSpan.FromSeconds(secondsbetweengenerations);
                NumberVehicles = int.Parse(args[1]);
                NumberToSpawn = int.Parse(args[2]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}