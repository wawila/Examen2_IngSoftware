using System;

namespace Examen2.Lexical
{
    internal class EndOfLineTokenizer : Tokenizer
    {
        public override TokenizerOutput Tokenize(string source)
        {
            char current = source[0];

            if (current != '\n')
                return null;

            Token token = new Token("\n", TokenType.EndOfLine);
            return new TokenizerOutput { Length = 1, Token = token };
        }
    }
}