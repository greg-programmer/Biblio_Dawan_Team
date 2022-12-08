using Biblioteque.Models;

namespace Biblioteque.Repository
{
    public interface IRepository<T> where T : AbstractEntity
    {
        List<T> FindAll();
        T FindById(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete (long id);
        void Commit();
    }
}
