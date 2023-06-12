namespace TDDBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_account_should_have_0_as_balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0m, ba.Balance);
        }

        [Fact]
        public void Can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(7m);

            Assert.Equal(7m, ba.Balance);
        }

        [Fact]
        public void Deposit_adds_to_Balance()
        {
            var ba = new BankAccount();

            ba.Deposit(7m);
            ba.Deposit(8m);

            Assert.Equal(15m, ba.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-4)]
        public void Deposit_negative_or_zero_value_throws_ArgumentEx(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(value));
        }

        [Fact]
        public void Can_withdraw()
        {
            var ba = new BankAccount();
            ba.Deposit(20m);

            ba.Withdraw(7m);

            Assert.Equal(13m, ba.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-4)]
        public void Withdraw_negative_or_zero_value_throws_ArgumentEx(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(value));
        }
    }
}