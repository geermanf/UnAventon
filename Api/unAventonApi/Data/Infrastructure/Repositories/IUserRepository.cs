using System.Threading.Tasks;

namespace unAventonApi.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
         Task<User> GetByEmail(string email);
    }
}