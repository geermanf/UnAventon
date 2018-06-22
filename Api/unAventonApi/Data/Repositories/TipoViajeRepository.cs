using unAventonApi.Data.Entities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class TipoViajeRepository : GenericRepository<TipoViaje>, ITipoViajeRepository
    {
        public TipoViajeRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

    }
}