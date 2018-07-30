using unAventonApi.Data.Entities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        public RolRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

    }
}