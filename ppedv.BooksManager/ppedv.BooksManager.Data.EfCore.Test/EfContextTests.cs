using FluentAssertions;
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
            string conStringKILLDB = "Server=(localdb)\\mssqllocaldb;Database=BooksManager_CreateTest;Trusted_Connection=true";

            var con = new EfContext(conStringKILLDB);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            //Assert.True(result);
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("", "Integration")]
        public void Can_create_Book()
        {
            var book = new Book() { Title = "Testbook" };
            var con = new EfContext(conString);
            con.Database.EnsureCreated();
            con.Add(book);
            var result = con.SaveChanges();

            //Assert.Equal(1, result);
            result.Should().Be(1);
        }

        [Fact]
        [Trait("", "Integration")]
        public void Can_read_Book()
        {
            var book = new Book() { Title = $"Testbook_{Guid.NewGuid()}" };
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(book);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                //Assert.Equal(book.Title, loaded.Title);
                loaded.Title.Should().Be(book.Title);
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
                con.Database.EnsureCreated();
                con.Add(book);
                con.SaveChanges();
            }
            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                loaded.Title = newTitle;
                con.SaveChanges().Should().Be(1);
            }
            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                loaded.Title.Should().Be(newTitle);
            }
        }

        [Fact]
        [Trait("", "Integration")]
        public void Can_delete_Book()
        {
            var book = new Book() { Title = $"Testbook_{Guid.NewGuid()}" };
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(book);
                con.SaveChanges();
            }
            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                con.Books.Remove(loaded);
                con.SaveChanges().Should().Be(1);
            }
            using (var con = new EfContext(conString))
            {
                var loaded = con.Books.Find(book.Id);
                loaded.Should().BeNull();
            }
        }
    }
}