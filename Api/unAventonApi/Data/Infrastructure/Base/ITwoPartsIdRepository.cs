using System.Linq;
using System.Threading.Tasks;

namespace unAventonApi.Data
{
    public interface ITwoPartsIdRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity GetByIds(int idUser,int idViaje);
        Task<TEntity> Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(int idUser,int idViaje);
    }
}