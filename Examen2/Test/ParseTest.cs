using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examen2.Parse;
using System.Collections.Generic;
using Examen2.Lexical;
using Examen2.Tree;

namespace Examen2.Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ParseHeader()
        {
            Parser parser = new Parser();
            List<Token> tokens = new List<Token>();

            tokens.Add(new Token("ID", TokenType.String));
            tokens.Add(new Token("AGE", TokenType.String));
            tokens.Add(new Token("DATE", TokenType.String));

            List<String> headers = new List<string>();

            CsvHeader header = parser.ParseHeaders(tokens);
            CsvHeader assertion = new CsvHeader();
            assertion.addHeader("ID");
            assertion.addHeader("AGE");
            assertion.addHeader("DATE");
        }

        [TestMethod]
        public void ParseValue()
        {
            Parser parser = new Parser();
            List<Token> tokens = new List<Token>();

            Token word = new Token("ID", TokenType.String);
            Token number = new Token("666", TokenType.Integer);
            Token date = new Token("#03/25/2017#", TokenType.Date);

            CsvValue stringValue = parser.ParseValue(word);
            CsvValue intValue = parser.ParseValue(number);
            CsvValue dateValue = parser.ParseValue(date);
        }

    }
}
