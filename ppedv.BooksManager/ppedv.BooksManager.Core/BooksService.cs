using ppedv.BooksManager.Data.EfCore;
using ppedv.BooksManager.Model;
using ppedv.BooksManager.Model.Contracts;

namespace ppedv.BooksManager.Core
{
    public class BooksService
    {
        private IRepository repo;

        public BooksService(IRepository repo)
        {
            this.repo = repo;
        }

        public Book GetBestBookByPricePerPageCost()
        {
            // Retrieve all books from the repository
            var books = repo.GetAll<Book>();

            // Calculate the price per page cost for each book
            var booksWithPricePerPageCost = books.Select(book => new
            {
                Book = book,
                PricePerPageCost = book.Price / book.Pages
            });

            // Find the book with the lowest price per page cost
            var bestBook = booksWithPricePerPageCost.OrderBy(b => b.PricePerPageCost).FirstOrDefault()?.Book;

            return bestBook;
        }

    }
}