using unAventonApi.Data.Entities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class TipoTarjetaRepository : GenericRepository<TipoTarjeta>, ITipoTarjetaRepository
    {
        public TipoTarjetaRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

    }
}