using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public User GetById(int id)
        {
            return _dbContext.Users
                    .Include(x => x.Tarjetas).ThenInclude(t => t.Banco)
                    .Include(x => x.Tarjetas).ThenInclude(t => t.Tipo)
                    .Include(z => z.Vehiculos)
                    .FirstOrDefault(x => x.Id == id);
        }

        public IList<Vehiculo> GetVehiculos(int id)
        {
            var user = this.GetById(id);
            return user.Vehiculos;
        }
        public IList<Tarjeta> GetTarjetas(int id)
        {
            var user = this.GetById(id);
            return user.Tarjetas;
        }
    }
}