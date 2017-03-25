using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Tree
{
    class CsvDate : CsvValue
    {
        public CsvDate(string Data) : base(Data)
        {
            this.Data= Data.Substring(1, 10);
        }
    }
}
