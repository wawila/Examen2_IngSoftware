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
            tokens.Add(new Token(",", TokenType.Delimiter));
            tokens.Add(new Token("AGE", TokenType.String));
            tokens.Add(new Token(",", TokenType.Delimiter));
            tokens.Add(new Token("DATE", TokenType.String));
            tokens.Add(new Token("\n", TokenType.EndOfLine));
            tokens.Add(new Token("1", TokenType.String));
            tokens.Add(new Token(",", TokenType.Delimiter));
            tokens.Add(new Token("25", TokenType.String));
            tokens.Add(new Token(",", TokenType.Delimiter));
            tokens.Add(new Token("#03-25-1994#", TokenType.String));

            List<String> headers = new List<string>();

            ParserOutput output = parser.ParseHeaders(tokens);
            CsvHeader header = (CsvHeader)output.Result;
            CsvHeader assertion = new CsvHeader();
            assertion.addHeader("ID");
            assertion.addHeader("AGE");
            assertion.addHeader("DATE");

            Assert.AreEqual(header,assertion);
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

            CsvString assertStringValue = new CsvString("ID");
            CsvInteger assertIntValue = new CsvInteger("666");
            CsvDate assertDateValue = new CsvDate("#03/25/2017#");

            Assert.AreEqual(assertDateValue, dateValue);
            Assert.AreEqual(assertIntValue, intValue);
            Assert.AreEqual(assertDateValue, dateValue);
        }

        [TestMethod]
        public void ParseRow()
        {
            Parser parser = new Parser();
            List<Token> tokens = new List<Token>();

            tokens.Add(new Token("ID", TokenType.String));
            tokens.Add(new Token(",", TokenType.Delimiter));
            tokens.Add(new Token("25", TokenType.Integer));
            tokens.Add(new Token(",", TokenType.Delimiter));
            tokens.Add(new Token("#03-25-1994#", TokenType.Date));
            tokens.Add(new Token("\n", TokenType.EndOfLine));

            ParserOutput output = parser.ParseRow(tokens);
            CsvRow row = (CsvRow)output.Result;

            CsvRow assertion = new CsvRow();
            assertion.addValue(new CsvString("ID"));
            assertion.addValue(new CsvInteger("25"));
            assertion.addValue(new CsvDate("#03-25-1994#"));
            Assert.AreEqual(row, assertion);
        }

    }
}
