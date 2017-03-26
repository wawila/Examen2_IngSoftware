using System;
using System.Collections.Generic;

namespace Examen2.Tree
{
    public class CsvTree
    {
        public CsvHeader Headers { get; set; }
        public List<CsvRow> Rows { get; set; }

        public CsvTree()
        {
            Headers = new CsvHeader();
            Rows = new List<CsvRow>();
        }

        public void addRow(CsvRow row)
        {
            Rows.Add(row);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CsvTree))
                return false;
            CsvTree other = (CsvTree)obj;

            for (int i = 0; i < Rows.Count; i++)
                if (!Rows[i].Equals(other.Rows[i]))
                    return false;
            return Headers.Equals(other.Headers);
        }
    }
}