using System.Linq;
using System.Threading.Tasks;

namespace unAventonApi.Data
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(int id);

        TEntity GetById(int id);

        // Task Create(TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task UpdateAsync(int id, TEntity entity);

        void Update(int id, TEntity entity);

        Task DeleteAsync(int id);

        void Delete(int id);
    }
}