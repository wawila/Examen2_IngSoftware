using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2.Lexical;
using Examen2.Tree;

namespace Examen2.Converters
{
    public class CsvtoJson
    {
        private readonly CsvTree _cvsTree;

        public CsvtoJson(CsvTree cvsTree)
        {
            this._cvsTree = cvsTree;
        }

        private string getJsonValue(CsvValue value)
        {
            switch (value.GetType().Name)
            {
                case nameof(CsvDate):
                    return '\"' + DateTime.Parse(value.Data).ToString("o") + '\"';
                case nameof(CsvInteger):
                    return value.Data;
                default:
                    return '\"' + value.Data + '\"';
            }

        }

        public string ToJson()
        {
            var json = "{\n";

            var index = 0;
            foreach (var row in _cvsTree.Rows)
            {
                json += "\t\"" + index + "\":{\n";
                for (var j = 0; j < row.Values.Count; j++)
                {
                    json += "\t\t\"" + _cvsTree.Headers.headers[j] + "\":";
                    json += getJsonValue(row.Values[j]);
                    json += ",\n";
                }

                index++;
            }

            json += "}";
            return json;
        }
    }
}
