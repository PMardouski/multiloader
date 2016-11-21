using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MultiLoader.Shared;

namespace MultiLoader.CSVLoader
{
    public class CSVReader
    {
        private static readonly CSVReader instance = new CSVReader();

        public string Name { get; private set; }

        private CSVReader()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static CSVReader GetInstance()
        {
            return instance;
        }

        public IEnumerable<DataModel> LoadData(string loadFrom)
        {
            return File.ReadAllLines(loadFrom)
                                           .Skip(1)
                                           .Select(FromCsv)
                                           .ToList();
        }

        private DataModel FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new DataModel
            {
                Date = Convert.ToDateTime(values[0]),
                Open = Convert.ToDecimal(values[1]),
                High = Convert.ToDecimal(values[2]),
                Low = Convert.ToDecimal(values[3]),
                Close = Convert.ToDecimal(values[4]),
                Volume = Convert.ToDecimal(values[5])
            };
        }
    }
}
