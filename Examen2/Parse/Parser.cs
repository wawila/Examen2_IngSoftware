using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2.Lexical;
using Examen2.Test;
using Examen2.Tree;

namespace Examen2.Parse
{
    public class Parser
    {
        internal CsvHeader ParseHeaders(List<Token> tokens)
        {
            return null;
        }

        public CsvValue ParseValue(Token token)
        {
            CsvValue value = null;

            switch(token.Type)
            {
                case TokenType.Integer:
                    value = new CsvInteger(token.Lexeme);
                    break;
                case TokenType.Date:
                    value = new CsvDate(token.Lexeme);
                    break;
                case TokenType.String:
                    value = new CsvString(token.Lexeme);
                    break;
            }
            return value;
        }
    }
}
