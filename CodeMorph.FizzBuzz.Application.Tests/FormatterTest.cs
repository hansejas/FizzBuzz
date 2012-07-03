using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeMorph.FizzBuzz.Application.Tests
{
    /// <summary>
    /// Tests for CodeMorph.FizzBuzz.Application.Formatter
    /// </summary>
    [TestClass]
    public class FormatterTest
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Tests fizzbuzz formatter with valid data
        /// </summary>
        [TestMethod]
        public void FormatInteger_ReplaceMod3WithFizzAdMod5WithBuzzRawNumber15_Valid()
        {
            //Arrange
            var formatter = new Formatter() { Maximum = 100, Minimum = 1 };
            formatter.TokenMapper.Add(3, "Fizz");
            formatter.TokenMapper.Add(5, "Buzz");
            int rawNumber = 15;
            var expectedResult = "FizzBuzz";
        
            //Act
            var actualResult = formatter.FormatInteger(rawNumber);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Tests fizzbuzz formatter with valid data
        /// </summary>
        [TestMethod]
        public void FormatInteger_ReplaceMod3WithFizzAdMod5WithBuzzRawNumber10_Valid()
        {
            //Arrange
            var formatter = new Formatter() { Maximum = 100, Minimum = 1 };
            formatter.TokenMapper.Add(3, "Fizz");
            formatter.TokenMapper.Add(5, "Buzz");
            int rawNumber = 10;
            var expectedResult = "Buzz";

            //Act
            var actualResult = formatter.FormatInteger(rawNumber);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Tests fizzbuzz formatter with valid data
        /// </summary>
        [TestMethod]
        public void FormatInteger_ReplaceMod3WithFizzAdMod5WithBuzzRawNumber9_Valid()
        {
            //Arrange
            var formatter = new Formatter() { Maximum = 100, Minimum = 1 };
            formatter.TokenMapper.Add(3, "Fizz");
            formatter.TokenMapper.Add(5, "Buzz");
            int rawNumber = 10;
            var expectedResult = "Fizz";

            //Act
            var actualResult = formatter.FormatInteger(rawNumber);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Tests fizzbuzz formatter with invalid data
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidFormatterRangeException))]
        public void FormatInteger_ReplaceMod3WithFizzAdMod5WithBuzzRawNumber9_InvalidFormatterRangeException()
        {
            //Arrange
            var formatter = new Formatter() { Maximum = 1, Minimum = 10 };
            formatter.TokenMapper.Add(3, "Fizz");
            formatter.TokenMapper.Add(5, "Buzz");
            int rawNumber = 10;

            //Act
            var actualResult = formatter.FormatInteger(rawNumber);

            //Assert omitted as we are testing for an expected exception
        }

        /// <summary>
        /// Tests fizzbuzz formatter with invalid data
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidTokenMapperException))]
        public void FormatInteger_ReplaceMod3WithFizzAdMod5WithBuzzRawNumber9_InvalidTokenMapperException()
        {
            //Arrange
            var formatter = new Formatter() { Maximum = 10, Minimum = 1 };
            // we are not configuring TokenMapper therefore it should complain that it has not been configured
            int rawNumber = 10;

            //Act
            var actualResult = formatter.FormatInteger(rawNumber);

            //Assert omitted as we are testing for an expected exception
        }

    }
}
