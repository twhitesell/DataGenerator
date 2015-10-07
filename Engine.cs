using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    class Engine
    {
        public Engine(SpnLookup lookup, SessionParameters p)
        {

        }

        public void Start()
        {





        }

        public void Stop()
        {
        }

        public void ResetParameters(SessionParameters p)
        {
            
        }

        public void ResetLookup(SpnLookup lookup)
        {
            
        }
    }

    internal class SessionParameters
    {
        public TimeSpan frequency;
        public int numberVehicles;
        public int numberToSpawn;
    }
}
