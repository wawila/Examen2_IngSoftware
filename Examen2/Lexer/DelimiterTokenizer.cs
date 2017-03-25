using System;

namespace Examen2.Lexical
{
    internal class DelimiterTokenizer : Tokenizer
    {
        public override TokenizerOutput Tokenize(string source)
        {
            char current = source[0];

            if (current != ',')
                return null;

            Token token = new Token(",", TokenType.Delimiter);
            return new TokenizerOutput { Length = 1, Token = token };
        }
    }
}