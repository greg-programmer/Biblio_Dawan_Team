using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        protected BiblioContext context;
        protected DbSet<T> dbSet;

        public Repository(BiblioContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public virtual void Delete(long id)
        {
            var t = FindById(id);
            if (context.Entry(t).State == EntityState.Detached)//Si il n'est pas attaché au context alors on l'attache au context
            {
                dbSet.Attach(t);
            }
            dbSet.Remove(t);
        }

        public virtual List<T> FindAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual T FindById(long id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}