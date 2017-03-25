using System;
using System.Collections.Generic;

namespace Examen2.Tree
{
    public class CsvHeader
    {
        public List<string> headers { get; set; }

        public CsvHeader()
        {
            headers = new List<string>();
        }

        public void addHeader(string header)
        {
            headers.Add(header);
        }

        public String getHeader(int index)
        {
            return index > headers.Count ? headers[index] : null;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CsvHeader))
                return false;

            CsvHeader other = (CsvHeader)obj;

            if (headers.Count != other.headers.Count)
                return false;

            for (int i = 0; i < headers.Count; i++)
            {
                if (headers[i] != other.headers[i])
                    return false;
            }

            return true;
        }
    }
}