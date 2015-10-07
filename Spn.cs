using System;
using System.Linq;

namespace DataGenerator
{
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
            ValuePostscript = string.Empty;
            ParseDataRangeField();

        }

        private void ParseDataRangeField()
        {
            
            if (RawDataRangeField.Contains("\""))
            {
                RawDataRangeField = RawDataRangeField.Replace("\"", "");
            }

            var replaced = RawDataRangeField.Replace("to", "|");
            var replacedTO = replaced.Replace("TO", "|");
            var replacedpercent = replacedTO.Replace("%", " %");
            var split = replacedpercent.Split('|');
            var lowstring = split[0];
            var cleaned = split[1].Trim();
            if (cleaned.Contains("mAhr (64.255Ahr)"))
            {
                cleaned = cleaned.Replace("mAhr (64.255Ahr)", " mAhr");
            }

            var splithigh = cleaned.Split(' ');
            if (splithigh.Count() > 1)
            {
                ValuePostscript = splithigh[1];
            }
            var splitlow = lowstring.Split(' ');
            if (splitlow.Count() > 1)
            {
                lowstring = splitlow[0].Trim();
            }

            Lowvalue = decimal.Parse(lowstring);
            Highvalue = decimal.Parse(splithigh[0]);
            Factor = GetPrecision(Highvalue);


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