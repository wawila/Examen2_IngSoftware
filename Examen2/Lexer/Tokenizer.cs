using System;

namespace Examen2.Lexical
{
    public abstract class Tokenizer
    {
        public abstract TokenizerOutput Tokenize(String source);

        protected char Peak(int cursor, String source)
        {
            return cursor < source.Length ? source[cursor] : source[source.Length - 1];
        }
    }
}