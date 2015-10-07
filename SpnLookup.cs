using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    internal class SpnLookup
    {


        public Int32 SpnCount;
       


        public SpnLookup(string columnHeaders, List<String> lines)
        {


            foreach (var line in lines)
            {
                



            }

            
        }

    }

    internal class Spn
    {
        public int SpnNumber;
        public string SpnName;
        public decimal Lowvalue;
        public decimal Highvalue;
        public int Factor;
        public string ValuePostscript;
        public int PgnNumber;
        public string PgnLabel;
        private string RawDataRangeField;


        public Spn(string line)
        {
            var split = line.Split('\t');
            if (split.Count() < 5)
            {
                throw new ArgumentOutOfRangeException("invalid row");
            }
            PgnNumber = Int32.Parse(split[0]);
            PgnLabel = split[1];
            SpnNumber = Int32.Parse(split[2]);
            SpnName = split[3];
            RawDataRangeField = split[4];
            ParseDataRangeField();

        }

        private void ParseDataRangeField()
        {
            
            if (RawDataRangeField.Contains("\""))
            {
                RawDataRangeField = RawDataRangeField.Replace("\"", "");
            }

            var replaced = RawDataRangeField.Replace("to", "|");

            var split = replaced.Split('|');
            var lowstring = split[0];
            var cleaned = split[1].Trim();
            var splithigh = cleaned.Split(' ');
            ValuePostscript = splithigh[1];
            Lowvalue = decimal.Parse(lowstring);
            Highvalue = decimal.Parse(splithigh[0]);
            Factor = GetPrecision(Lowvalue);


        }


        private int GetPrecision(decimal x)
        {
            var precision = 0;

            while (x * (decimal)Math.Pow(10, precision) !=
                     Math.Round(x * (decimal)Math.Pow(10, precision)))
            {
                precision++;
            }
            return Math.Min(precision, 2);
        }

    }
}
