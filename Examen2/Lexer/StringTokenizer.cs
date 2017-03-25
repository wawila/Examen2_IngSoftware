using System;

namespace Examen2.Lexical
{
    public class StringTokenizer : Tokenizer
    {
        public override TokenizerOutput Tokenize(string source)
        {
            String lexeme = "";
            int cursor = 0;
            
            bool success = false;
            char current = source[cursor];
            
            while (cursor < source.Length && Char.IsLetterOrDigit(current))
            {
                success = true;
                lexeme += current;
                current = Peak(++cursor, source);
            }

            if (lexeme.Length > 0 && cursor < source.Length)
                success = (Char.IsWhiteSpace(current) || current == ',');

            return success ? new TokenizerOutput { Length = cursor, Token = new Token(lexeme, TokenType.String) } : null;
        }
    }
}