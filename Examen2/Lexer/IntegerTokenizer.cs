using System;

namespace Examen2.Lexical
{
    public class IntegerTokenizer : Tokenizer
    {
        public override TokenizerOutput Tokenize(string source)
        {
            int cursor = 0;
            char current = Peak(cursor, source);
            string lexeme = "";
            bool success = false;
            while(cursor < source.Length && char.IsDigit(current))
            {
                success = true;
                lexeme += current;
                current = Peak(++cursor, source);
            }

            if (lexeme.Length > 0 && cursor < source.Length)
                success = (Char.IsWhiteSpace(current) || current == ',');

            return success ? new TokenizerOutput { Length = cursor, Token = new Token(lexeme, TokenType.Integer) } : null;
        }
    }
}