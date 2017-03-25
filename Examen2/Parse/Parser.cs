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
        internal ParserOutput ParseHeaders(List<Token> tokens)
        {
            int cursor = 0;
            CsvHeader header = new CsvHeader();
            ParserOutput output = new ParserOutput();
            Token current = Peak(cursor, tokens);
            while(cursor < tokens.Count && current.Type != TokenType.EndOfLine)
            {
                if(current.Type != TokenType.Delimiter)
                    header.addHeader(current.Lexeme);
                current = Peak(++cursor, tokens);
            }
            output.Result = header;
            output.Length = cursor;
            return output;
        }

        private Token Peak(int cursor, List<Token> tokens)
        {
            return cursor < tokens.Count ? tokens[cursor] : tokens[tokens.Count - 1];
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

        public ParserOutput ParseRow(List<Token> tokens)
        {
            int cursor = 0;
            CsvRow row = new CsvRow();
            ParserOutput output = new ParserOutput();
            Token current = Peak(cursor, tokens);
            while (cursor < tokens.Count)
            {
                if (current.Type == TokenType.EndOfLine)
                    break;

                CsvValue value = ParseValue(current);

                if (value == null)
                    throw new InvalidToken($"Invalid token at ({current.Row}, {current.Column})");

                current = Peak(++cursor, tokens);

                if(current.Type != TokenType.Delimiter && current.Type != TokenType.EndOfLine)
                    throw new InvalidToken($"Invalid token at ({current.Row}, {current.Column}), Expected token: Delimiter");
                current = Peak(++cursor, tokens);
                row.addValue(value);
            }
            output.Result = row;
            output.Length = cursor;
            return output;
        }
    }
}
