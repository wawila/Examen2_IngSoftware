using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Tree
{
    public abstract class CsvValue
    {
        public CsvValue(String Data)
        {
            this.Data = Data;
        }

        public string Data { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is CsvValue))
                return false;
            CsvValue other = (CsvValue)obj;
            return Data == other.Data;
        }
    }
}
