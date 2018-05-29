using System.Linq;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class TarjetaRepository : GenericRepository<Tarjeta>, ITarjetaRepository
    {
        public TarjetaRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

    }
}