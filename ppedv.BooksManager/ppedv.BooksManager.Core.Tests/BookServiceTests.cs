using ppedv.BooksManager.Model;
using ppedv.BooksManager.Model.Contracts;

namespace ppedv.BooksManager.Core.Tests
{
    public class BookServiceTests
    {
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