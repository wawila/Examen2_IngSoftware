using System;

namespace Examen2.Lexical
{
    internal class DateTokenizer : Tokenizer
    {
        public override TokenizerOutput Tokenize(string source)
        {
            int cursor = 0;

            if (Peak(cursor, source) != '#')
                return null;

            string lexeme = source.Substring(1, 10);

            DateTime date;
            bool success = DateTime.TryParse(lexeme, out date);

            if (!success)
                return null;

            if (source[cursor++] != '#')
                return null;
            Token token = new Token("#" + lexeme + "#", TokenType.Date);
            return new TokenizerOutput { Length = lexeme.Length + 2, Token = token};
        }
    }
}