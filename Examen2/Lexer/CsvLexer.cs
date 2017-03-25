using System;
using System.Collections.Generic;

namespace Examen2.Lexical
{
    public class CsvLexer : Lexer
    {
        public string Source { get; set; }
        public List<Tokenizer> tokenizers;
        private int _cursor;
        private int _column;
        private int _row;
        public CsvLexer()
        {
            tokenizers = new List<Tokenizer>();
            tokenizers.Add(new IntegerTokenizer());
            tokenizers.Add(new DateTokenizer());
            tokenizers.Add(new StringTokenizer());
            tokenizers.Add(new EndOfLineTokenizer());
            tokenizers.Add(new WhitespaceTokenizer());
        }

        public override List<Token> Lex()
        {
            List<Token> tokens = new List<Token>();
            _cursor = 0;
            while (_cursor < Source.Length)
            {
                Token token = null;
                foreach(Tokenizer tokenizer in tokenizers)
                {
                    String substring = Source.Substring(_cursor, Source.Length - _cursor);

                    TokenizerOutput output = tokenizer.Tokenize(substring);

                    if (output == null)
                        continue;

                    token = output.Token;
                    _cursor += output.Length;

                    if(token.Type != TokenType.Whitespace)
                        tokens.Add(token);

                    if (token.Type == TokenType.EndOfLine)
                    {
                        _row++;
                        _column = 0;
                    }
                    else
                        _column += token.Lexeme.Length;
                    break;
                    
                }

                if (token == null)
                    throw new IllegalTokenException($"Illegal token at ({_row}, {_column}) => {Source[_cursor]}");

            }
            return tokens;
        }
    }
}