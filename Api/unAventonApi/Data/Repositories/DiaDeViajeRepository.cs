using unAventonApi.Data.Entities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class DiaDeViajeRepository : GenericRepository<DiaDeViaje>, IDiaDeViajeRepository
    {
        public DiaDeViajeRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

    }
}