using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examen2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateCSVCorrect()
        {
            const string csvFile = "./Bueno.csv";
            var auxFunctions = new AuxiliaryFunctions();

            Assert.IsTrue(auxFunctions.ValidateCSV(csvFile));
        }

        [TestMethod]
        public void ValidateCSVWrong()
        {
            const string csvFile = "./Malo.csv";
            var auxFunctions = new AuxiliaryFunctions();

            Assert.IsFalse(auxFunctions.ValidateCSV(csvFile));
        }

        [TestMethod]
        public void InputTypeDateCorrect()
        {
            
        }

        [TestMethod]
        public void InputTypeDateWrong()
        {

        }

        [TestMethod]
        public void InputTypeIntegerCorrect()
        {

        }

        [TestMethod]
        public void InputTypeIntegerWrong()
        {

        }

        [TestMethod]
        public void InputTypeStringCorrect()
        {

        }

        [TestMethod]
        public void InputTypeStringWrong()
        {

        }

    }
}
