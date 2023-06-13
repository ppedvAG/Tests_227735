using ppedv.BooksManager.Model.Contracts;

namespace ppedv.BooksManager.Data.EfCore
{
    public class EfRepository : IRepository
    {
        public EfRepository(string conString)
        {
            context = new EfContext(conString);
        }

        EfContext context;
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : class
        {
            return context.Find<T>(id);
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }
    }
}
