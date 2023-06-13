using ppedv.BooksManager.Data.EfCore;
using ppedv.BooksManager.Model;
using ppedv.BooksManager.Model.Contracts;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Hello, World!");
string conString = "Server=(localdb)\\mssqllocaldb;Database=BooksManager_Dev;Trusted_Connection=true";

IRepository repo;

repo = new EfRepository(conString);

foreach (var b in repo.GetAll<Book>())
{
    Console.WriteLine($"{b.Title} Pages: {b.Pages} Price {b.Price:c}");
    foreach (var a in b.Authors)
    {
        Console.WriteLine($"\t{a.Name}");
    }
}


