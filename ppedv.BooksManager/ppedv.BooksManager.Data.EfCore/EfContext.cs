using Microsoft.EntityFrameworkCore;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        string conString;

        public EfContext(string conString)
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();
        }

    }
}