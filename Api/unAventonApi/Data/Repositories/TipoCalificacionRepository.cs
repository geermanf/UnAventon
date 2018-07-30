using unAventonApi.Data.Entities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class TipoCalificacionRepository : GenericRepository<TipoCalificacion>, ITipoCalificacionRepository
    {
        public TipoCalificacionRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

    }
}