using System.Linq;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Entities.TablasIntermedias;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class ViajerosRepository : TwoPartsIdRepository<Viajeros>, IViajerosRepository
    {
        public ViajerosRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

        public IQueryable<Viajeros> GetByIdViaje(int idViaje)
        {
            return _dbContext.Set<Viajeros>().Where(p => p.ViajeId == idViaje);
        }

    }
}