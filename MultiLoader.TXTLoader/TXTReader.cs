using System;
using System.Collections.Generic;
using System.IO;
using MultiLoader.Shared;

namespace MultiLoader.TXTLoader
{
    public class TXTReader
    {
        private static readonly TXTReader instance = new TXTReader();

        public string Name { get; private set; }

        private TXTReader()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static TXTReader GetInstance()
        {
            return instance;
        }

        public IEnumerable<DataModel> LoadData(string loadFrom)
        {
            IList<DataModel> lines = null;
            using (var sr = new StreamReader(loadFrom))
            {
                bool passedFirstline = false;
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    if (passedFirstline)
                    {
                        if(lines == null)
                            lines = new List<DataModel>();
                        lines.Add(FromTxt(line));
                    }
                    else
                    {
                        passedFirstline = true;
                    }
                }
            }

            return lines;
        }

        private DataModel FromTxt(string csvLine)
        {
            string[] values = csvLine.Split(';');
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
