using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    internal class SpnLookup
    {
        public string Header { get; set; }
        public Int32 SpnCount { get; set; }
        public Dictionary<int, Spn> Lookup { get; set; }

        public SpnLookup(string columnHeaders, List<String> lines)
        {
            Header = columnHeaders;
            Lookup = new Dictionary<int, Spn>();
            foreach (var line in lines)
            {
                var spn = new Spn(line);
                Lookup.Add(spn.SpnNumber, spn);
                SpnCount++;
            }

            
        }

    }
}
