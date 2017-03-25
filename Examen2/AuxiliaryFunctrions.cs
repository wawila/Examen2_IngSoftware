using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2.Test;

namespace Examen2
{
    public class CsvValidator
    {
        private readonly ISourceReader _sourceReader;
        private readonly string _path;

        public CsvValidator(ISourceReader sourceReader)
        {
            _sourceReader = sourceReader;
            _path = _sourceReader.Fetch();
        }

        public bool ValidateCSV()
        {
            var lines = File.ReadLines(_path);

            var enumerable = lines as string[] ?? lines.ToArray();
            var commaCount = AllIndexesOf(enumerable.First(), ",").Count;


            return enumerable.All(line => AllIndexesOf(line, ",").Count == commaCount);
        }

        public List<int> AllIndexesOf(string str, string value)
        {
            List<int> indexes = new List<int>();
            for (var index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index, StringComparison.Ordinal);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
