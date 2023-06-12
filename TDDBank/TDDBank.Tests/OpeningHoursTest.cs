using Microsoft.QualityTools.Testing.Fakes;

namespace TDDBank.Tests
{
    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2023, 1, 09, 10, 30, true)]//mo
        [InlineData(2023, 1, 09, 10, 29, false)]//mo
        [InlineData(2023, 1, 09, 10, 31, true)] //mo
        [InlineData(2023, 1, 09, 18, 59, true)] //mo
        [InlineData(2023, 1, 09, 19, 00, false)] //mo
        [InlineData(2023, 1, 14, 13, 0, true)] //sa
        [InlineData(2023, 1, 14, 16, 0, false)] //sa
        [InlineData(2023, 1, 15, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();


            Assert.Equal(result, oh.IsOpen(dt));
        }

        [Fact]
        public void IsWeekend()
        {
            var oh = new OpeningHours();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 6, 5);//Mo
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 6, 13);//Di
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 6, 14);//Mi
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 6, 15);//Do
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 6, 16);//Fr
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 6, 17);//Sa
                Assert.True(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 6, 18);//So
                Assert.True(oh.IsWeekend());
            }
        }

    }
}