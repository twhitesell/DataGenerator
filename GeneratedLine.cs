namespace DataGenerator
{
    internal  class GeneratedLine
    {
        public int vehicleId { get; set; }
        public string line { get; set; }

        public GeneratedLine(int vehid, string time, int spnNum, string val)
        {
            vehicleId = vehid;
            line = string.Format("[{0},{1},{2},{3}]", time, vehicleId, spnNum, val);
        }

    }
}