using System;
using System.Linq;

namespace Examen2
{
    class UnitConvertion
    {
        public bool ParseableToInt(string input)
        {
            int value;
            var parseable = int.TryParse(input, out value);
            return parseable;
        }

        public bool ParseableToDateTime(string input)
        {
            if(input.First() != '#' && input.Last() != '#')
                return false;
            
            DateTime value;
            var parseable = DateTime.TryParse(input, out value);
            return parseable;
        }

        public bool LeaveAsString(string input)
        {
            return !ParseableToDateTime(input) && !ParseableToInt(input);
        }
    }
}
