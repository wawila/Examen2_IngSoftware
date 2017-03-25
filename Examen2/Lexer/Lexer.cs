using System.Collections.Generic;

namespace Examen2.Lexical
{
    public abstract class Lexer
    {
        public abstract List<Token> Lex();
    }
}