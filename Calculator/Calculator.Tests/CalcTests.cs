namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        [Trait("TestType","UnitTest")]
        [Trait("ResultType","Exception")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(5, 4, 9)]
        [InlineData(-5, -4, -9)]
        [InlineData(-5, 7, 2)]
        public void Sum_good_values(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }

    }
}