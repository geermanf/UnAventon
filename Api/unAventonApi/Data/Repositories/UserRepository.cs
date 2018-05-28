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

        public Task<User> GetById(int id){
            return _dbContext.Users.Include(x => x.Tarjetas).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}