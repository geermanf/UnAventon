using unAventonApi.Data.Entities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class BancoRepositoty : GenericRepository<Banco>, IBancoRepository
    {
        public BancoRepositoty(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

    }
}