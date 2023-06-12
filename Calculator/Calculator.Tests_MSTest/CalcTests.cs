using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests_MSTest
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("Exception")]
        public void Sum_MIN_and_n1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Inconclusive();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MinValue, -1));
        }

   

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(5, 4, 9)]
        [DataRow(-5, -4, -9)]
        [DataRow(-5, 7, 2)]
        public void Sum_good_values(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(exp, result);
        }
    }
}