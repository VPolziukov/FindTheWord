using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindWord.DAL.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetAsync(params object[] id);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Delete(params object[] id);

        void Update(TEntity entity);
    }

}
