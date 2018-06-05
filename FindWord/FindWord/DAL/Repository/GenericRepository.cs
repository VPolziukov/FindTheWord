using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FindWord.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ContextDB context;

        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(ContextDB context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {

            return await dbSet.ToListAsync();

        }

        public virtual async Task<TEntity> GetAsync(params object[] id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(params object[] id)
        {
            TEntity entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }

}