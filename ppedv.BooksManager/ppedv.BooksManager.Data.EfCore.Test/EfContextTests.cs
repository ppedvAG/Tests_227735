using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Data.EfCore.Test
{
    public class EfContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=BooksManager_Dev;Trusted_Connection=true";

        [Fact]
        [Trait("", "Integration")]
        public void Can_create_DB()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        [Trait("", "Integration")]
        public void Can_create_Book()
        {
            var book = new Book() { Title = "Testbook" };
            var con = new EfContext(conString);
            con.Add(book);
            var result = con.SaveChanges();

            Assert.Equal(1, result);
        }

        [Fact]
        [Trait("", "Integration")]
        public void Can_read_Book()
        {
            var book = new Book() { Title = $"Testbook_{Guid.NewGuid()}" };
            using (var con = new EfContext(conString))
            {
                con.Add(book);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                Assert.Equal(book.Title, loaded.Title);
            }
        }

        [Fact]
        [Trait("", "Integration")]
        public void Can_update_Book()
        {
            var book = new Book() { Title = $"Testbook_{Guid.NewGuid()}" };
            var newTitle = $"NewBookTitle_{Guid.NewGuid()}";
            using (var con = new EfContext(conString))
            {
                con.Add(book);
                con.SaveChanges();
            }
            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                loaded.Title = newTitle;
                var rows = con.SaveChanges();
                Assert.Equal(1, rows);
            }
            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                Assert.Equal(newTitle, loaded.Title);
            }
        }

        [Fact]
        [Trait("", "Integration")]
        public void Can_delete_Book()
        {
            var book = new Book() { Title = $"Testbook_{Guid.NewGuid()}" };
            using (var con = new EfContext(conString))
            {
                con.Add(book);
                con.SaveChanges();
            }
            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                con.Books.Remove(loaded);
                var rows = con.SaveChanges();
                Assert.Equal(1, rows);
            }
            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                Assert.Null(loaded);
            }
        }
    }
}