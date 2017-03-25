using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2.Lexical;

namespace Examen2.Converters
{
    public class CsvtoXml
    {
        private readonly List<Token> _headers;
        private readonly List<List<Token>> _rows;

        public CsvtoXml(List<Token> headers, List<List<Token>> rows)
        {
            _headers = headers;
            _rows = rows;
        }

        private string getJsonValue(Token token)
        {
            switch (token.Type)
            {
                case TokenType.Date:
                    return '\"' + DateTime.Parse(token.Lexeme).ToString("o") + '\"';
                case TokenType.Number:
                    return token.Lexeme;
            }
            return '\"' + token.Lexeme + '\"';
        }

        public string ToXML()
        {
            var json = "<XML>\n";
            foreach (var t in _rows)
            {
                json += "\t<ROW>\n";
                for (var j = 0; j < _rows[0].Count; j++)
                {
                    json += "\t\t<" + _headers[j].Lexeme + "> ";
                    json += getJsonValue(t[j]);
                    json += "</" + _headers[j].Lexeme + ">\n";
                }
                json += "\t</ROW>\n";
            }

            json += "</XML>";
            return json;
        }

    }
}

