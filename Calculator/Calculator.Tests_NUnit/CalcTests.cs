namespace Calculator.Tests_NUnit
{
    public class CalcTests
    {
        [Test]
        [Category("UnitTest")]
        [Category("Exception")]
        public void Sum_MIN_and_n1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MinValue, -1));
        }

        [TestCase(0, 0, 0)]
        [TestCase(5, 4, 9)]
        [TestCase(-5, -4, -9)]
        [TestCase(-5, 7, 2)]
        public void Sum_good_values(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            //Assert.AreEqual(exp, result);
            Assert.That(result, Is.EqualTo(exp));
        }
    }
}