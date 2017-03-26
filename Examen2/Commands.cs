using System.Collections.Generic;
using System.IO;
using Examen2.Converters;
using Examen2.Tree;

namespace Examen2
{
    public class Commands
    {

        private CsvTree getTreeFromFile(string inputfile)
        {
            var path = inputfile;
            var csvTree = new CsvTree
            {
                Headers = new CsvHeader
                {
                    headers = new List<string>
                    {
                        "nombre",
                        "id",
                        "fecha"
                    }
                },
                Rows = new List<CsvRow>
                {
                    new CsvRow
                    {
                        Values = new List<CsvValue>
                        {
                            new CsvString("david"),
                            new CsvInteger("0"),
                            new CsvDate("#1996-04-23T00:00:00.0000000#")
                        }
                    },
                    new CsvRow
                    {
                        Values = new List<CsvValue>
                        {
                            new CsvString("napky"),
                            new CsvInteger("1"),
                            new CsvDate("#1996-04-23T00:00:00.0000000#")
                        }
                    }
                }
            };

            return csvTree;
        }

        public void ToJSON(string inputfile, string outputfile)
        {
            var cvsTree = getTreeFromFile(inputfile);
            File.WriteAllText(outputfile, new CsvtoJson(cvsTree).ToJson());
        }

        public void ToXML(string inputfile, string outputfile)
        {
            var cvsTree = getTreeFromFile(inputfile);
            File.WriteAllText(outputfile, new CsvtoXml(cvsTree).ToXML());
        }
    }
}