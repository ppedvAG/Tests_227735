namespace ppedv.BooksManager.Data.EfCore.Test
{
    public class EfContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=BooksManager_Dev;Trusted_Connection=true";

        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }
    }
}