using System;
using System.Collections.Generic;

namespace Examen2.Test
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
    }
}