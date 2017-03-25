using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examen2.Lexical;
using Moq;

namespace Examen2.Test
{
    /// <summary>
    /// Summary description for LexerTest
    /// </summary>
    [TestClass]
    public class LexerTest
    {
        private readonly Mock<ISourceReader> _sourceReader= new Mock<ISourceReader>();
       
        private TestContext testContextInstance;
        
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
    
        [TestMethod]
        public void TokenizeStrings()
        {
            _sourceReader.Setup(i => i.Fetch()).Returns("ID, NAME, AGE, DATE");
            CsvLexer lexer = new CsvLexer(_sourceReader.Object);
            List<Token> tokens =  lexer.Lex();
            List<Token> assertion = new List<Token>();

            assertion.Add(new Token("ID", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("NAME", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("AGE", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("DATE", TokenType.String));

            Assert.AreEqual(assertion.Count, tokens.Count);
            for (int i = 0; i < tokens.Count; i++)
                Assert.AreEqual(tokens[i], assertion[i]);    
        }

        [TestMethod]
        public void TokenizeInteger()
        {

            _sourceReader.Setup(i => i.Fetch()).Returns("69, 666, 4, 42 ");
            CsvLexer lexer = new CsvLexer(_sourceReader.Object);
            List<Token> tokens = lexer.Lex();
            List<Token> assertion = new List<Token>();

            assertion.Add(new Token("69", TokenType.Integer));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("666", TokenType.Integer));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("4", TokenType.Integer));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("42", TokenType.Integer));

            Assert.AreEqual(assertion.Count, tokens.Count);
            for (int i = 0; i < tokens.Count; i++)
                Assert.AreEqual(tokens[i], assertion[i]);
        }

        [TestMethod]
        public void TokenizeRow()
        {
            _sourceReader.Setup(i => i.Fetch()).Returns("ID, 666 \n SATAN, 69");
            CsvLexer lexer = new CsvLexer(_sourceReader.Object);
            List<Token> tokens = lexer.Lex();
            List<Token> assertion = new List<Token>();

            assertion.Add(new Token("ID", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("666", TokenType.Integer));
            assertion.Add(new Token("\n", TokenType.EndOfLine));
            assertion.Add(new Token("SATAN", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("69", TokenType.Integer));

            Assert.AreEqual(assertion.Count, tokens.Count);
            for (int i = 0; i < tokens.Count; i++)
                Assert.AreEqual(tokens[i], assertion[i]);
        }

        [TestMethod]
        public void TokenizeDates()
        {
            _sourceReader.Setup(i => i.Fetch()).Returns("#03/25/2017#, #02/11/2013#, #06/06/2006#");
            CsvLexer lexer = new CsvLexer(_sourceReader.Object);
            List<Token> tokens = lexer.Lex();
            List<Token> assertion = new List<Token>();

            assertion.Add(new Token("#03/25/2017#", TokenType.Date));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("#02/11/2013#", TokenType.Date));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("#06/06/2006#", TokenType.Date));

            Assert.AreEqual(assertion.Count, tokens.Count);
            for (int i = 0; i < tokens.Count; i++)
                Assert.AreEqual(tokens[i], assertion[i]);
        }

        [TestMethod]
        public void TokenizeCsv()
        {
            _sourceReader.Setup(i => i.Fetch()).Returns("ID, NAME, AGE, DATE \n 1, Brandon, 66, #03/25/2017# \n 2, David, 69, #05/30/1994# \n");
            CsvLexer lexer = new CsvLexer(_sourceReader.Object);
            List<Token> tokens = lexer.Lex();
            List<Token> assertion = new List<Token>();

            assertion.Add(new Token("ID", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("NAME", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("AGE", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("DATE", TokenType.String));
            assertion.Add(new Token("\n", TokenType.EndOfLine));
            assertion.Add(new Token("1", TokenType.Integer));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("Brandon", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("66", TokenType.Integer));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("#03/25/2017#", TokenType.Date));
            assertion.Add(new Token("\n", TokenType.EndOfLine));
            assertion.Add(new Token("2", TokenType.Integer));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("David", TokenType.String));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("69", TokenType.Integer));
            assertion.Add(new Token(",", TokenType.Delimiter));
            assertion.Add(new Token("#05/30/1994#", TokenType.Date));
            assertion.Add(new Token("\n", TokenType.EndOfLine));


            Assert.AreEqual(assertion.Count, tokens.Count);
            for (int i = 0; i < tokens.Count; i++)
                Assert.AreEqual(tokens[i], assertion[i]);
        }

        [TestMethod]
        public void ValidateCsvCorrect()
        {
            _sourceReader.Setup(i => i.Fetch()).Returns("./Bueno.csv");
            var validator = new CsvValidator(_sourceReader.Object);

            Assert.IsTrue(validator.ValidateCSV());
        }

        [TestMethod]
        public void ValidateCsvWrong()
        {
            _sourceReader.Setup(i => i.Fetch()).Returns("./Malo.csv");
            var validator = new CsvValidator(_sourceReader.Object);

            Assert.IsFalse(validator.ValidateCSV());
        }
    }
}
