using FluentAssertions;
using Moq;
using ppedv.BooksManager.Model;
using ppedv.BooksManager.Model.Contracts;

namespace ppedv.BooksManager.Core.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetBestBookByPricePerPageCost_3_books_ArtOfUnitTesting_is_best_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Book>()).Returns(() =>
            {
                var b1 = new Book() { Title = "SQL Server 2005", Price = 100, Pages = 10 };
                var b2 = new Book() { Title = "The Art of Unit Testing", Price = 100, Pages = 30 };
                var b3 = new Book() { Title = "Design Patterns", Price = 100, Pages = 20 };
                return new[] { b1, b2, b3 };
            });
            var bs = new BooksService(mock.Object);

            var result = bs.GetBestBookByPricePerPageCost();

            result.Title.Should().Be("The Art of Unit Testing");
        }

        [Fact]
        public void GetBestBookByPricePerPageCost_no_books_in_DB_should_return_null()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Book>()).Returns(() => new List<Book>());
            var bs = new BooksService(mock.Object);

            bs.GetBestBookByPricePerPageCost().Should().BeNull();
        }

        [Fact]
        public void GetBestBookByPricePerPageCost_book_with_zero_pages_should_not_throw_DivByZeroException_and_should_not_be_calculated()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Book>()).Returns(() =>
            {
                var b1 = new Book() { Title = "SQL Server 2005", Price = 100, Pages = 10 };
                var b2 = new Book() { Title = "The Art of Unit Testing", Price = 100, Pages = 30 };
                var b3 = new Book() { Title = "Alles was besser an Windows 11 ist", Price = 100, Pages = 0 };
                var b4 = new Book() { Title = "Design Patterns", Price = 100, Pages = 20 };
                return new[] { b1, b2, b3, b4 };
            });
            var bs = new BooksService(mock.Object);

            var result = bs.GetBestBookByPricePerPageCost();

            result.Title.Should().Be("The Art of Unit Testing");
        }


        [Fact]
        public void GetBestBookByPricePerPageCost_two_book_with_same_page_price_ratio_should_return_the_newer()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Book>()).Returns(() =>
            {
                var b1 = new Book() { Title = "SQL Server 2005", Price = 100, Pages = 10, PublishDate = new DateTime(3005, 1, 1) };
                var b2 = new Book() { Title = "The Art of Unit Testing", Price = 100, Pages = 30, PublishDate = new DateTime(2013, 1, 1) };
                var b3 = new Book() { Title = "Warum man bei Windows 10 bleiben sollte", Price = 100, Pages = 30, PublishDate = new DateTime(2022, 1, 1) };
                var b4 = new Book() { Title = "Design Patterns", Price = 100, Pages = 20, PublishDate = new DateTime(1994, 1, 1) };
                return new[] { b1, b2, b3, b4 };
            });
            var bs = new BooksService(mock.Object);

            var result = bs.GetBestBookByPricePerPageCost();

            result.Title.Should().Be("Warum man bei Windows 10 bleiben sollte");
        }



        [Fact]
        public void GetBestBookByPricePerPageCost_3_books_ArtOfUnitTesting_is_best()
        {
            var bs = new BooksService(new TestRepo());

            var result = bs.GetBestBookByPricePerPageCost();

            Assert.Equal("The Art of Unit Testing", result.Title);
        }
    }

    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            if (typeof(T) == typeof(Book))
            {
                var b1 = new Book() { Title = "SQL Server 2005", Price = 100, Pages = 10 };
                var b2 = new Book() { Title = "The Art of Unit Testing", Price = 100, Pages = 30 };
                var b3 = new Book() { Title = "Design Patterns", Price = 100, Pages = 20 };

                return new[] { b1, b2, b3 }.Cast<T>();
            }

            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}