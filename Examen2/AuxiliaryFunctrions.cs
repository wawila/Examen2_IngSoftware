using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class AuxiliaryFunctions
    {
        public bool ValidateCSV(string path)
        {
            var lines = File.ReadLines(path);

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
