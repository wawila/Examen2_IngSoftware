using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2.Converters;
using Examen2.Tree;

namespace Examen2
{
    public class Program
    {
        public static int Main(string[] args)
        {

            var testxml =
             @"<XML>
                <ROW>
                    <nombre> david </nombre>
                    <id> 0 </id>
                    <fecha> 1996-04-23 </fecha>        
                </ROW>
                <ROW>
                    <nombre> napky </nombre>
                    <id> 1 </id>
                    <fecha> 1996-04-23 </fecha>        
                </ROW>
            </XML>".Replace("\r", "").Replace(" ", "");

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

            var outputxml = new CsvtoXml(csvTree).ToXML().Replace("\t", "").Replace(" ", "");
            
            Console.Out.WriteLine(testxml);
            Console.Out.WriteLine("-------------------------------");
            Console.Out.WriteLine(outputxml);
            Console.Out.WriteLine("-------------------------------");
            Console.Out.WriteLine(outputxml == testxml);


            /*
            var shell = new Shell();
            shell.RunShell();
            */

            Console.ReadKey();
            return 0;
        }
    }
}
