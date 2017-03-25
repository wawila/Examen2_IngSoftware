using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2.Lexical;
using Examen2.Tree;

namespace Examen2.Converters
{
    public class CsvtoXml : IConverter
    {
        private readonly CsvTree _csvTree;

        public CsvtoXml(CsvTree csvTree)
        {
            this._csvTree = csvTree;
        }
        
        public string ToXML()
        {
            var xml = "<XML>\n";
            foreach (var row in _csvTree.Rows)
            {
                xml += "\t<ROW>\n";
                for (var j = 0; j < row.Values.Count; j++)
                {
                    xml += "\t\t<" + _csvTree.Headers.headers[j] + "> ";
                    xml += row.Values[j].Data;
                    xml += " </" + _csvTree.Headers.headers[j] + ">\n";
                }
                xml += "\t</ROW>\n";
            }

            xml += "</XML>";
            return xml;
        }

        public string ConvertCsv()
        {
            return ToXML();
        }
    }
}

