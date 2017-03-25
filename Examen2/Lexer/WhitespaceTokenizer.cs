using System;

namespace Examen2.Lexical
{
    internal class WhitespaceTokenizer : Tokenizer
    {
        public override TokenizerOutput Tokenize(string source)
        {
            int cursor = 0;
            Char current = source[cursor];
            string lexeme = "";
            while (cursor < source.Length && (Char.IsWhiteSpace(current)) && current != '\n')
            {
                lexeme += current;
                current = Peak(++cursor, source);

            }
            Token token = cursor > 0 ? new Token(lexeme, TokenType.Whitespace) : null;
            return new TokenizerOutput { Length = cursor, Token = token };
        }
    }
}