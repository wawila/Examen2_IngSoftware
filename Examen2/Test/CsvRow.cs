using System;
using Examen2.Tree;
using System.Collections.Generic;

namespace Examen2.Test
{
    public class CsvRow
    {
        public List<CsvValue> Values { get; set; }

        public CsvRow()
        {
            Values = new List<CsvValue>();
        }

        internal void addValue(CsvValue value)
        {
            Values.Add(value);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CsvRow))
                return false;
            CsvRow other = (CsvRow)obj;

            if (other.Values.Count != Values.Count)
                return false;

            for (int i = 0; i < Values.Count; i++)
                if (!Values[i].Equals(other.Values[i]))
                    return false;
            return true;
        }
    }
}