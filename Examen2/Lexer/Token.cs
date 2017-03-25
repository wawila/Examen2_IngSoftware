using Examen2.Lexical;

namespace Examen2.Lexical
{
    public class Token
    {
        public string Lexeme;
        public TokenType Type;

        public Token(string lexeme, TokenType type)
        {
            this.Lexeme = lexeme;
            this.Type = type;
        }

        public int Row { get;  set; }
        public int Column { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Token))
                return false;

            Token other = (Token)obj;
            return other.Lexeme == Lexeme 
               && Type == other.Type;
        }
    }
}