using System.Collections.Generic;
using System.Threading.Tasks;

namespace unAventonApi.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        IList<Vehiculo> GetVehiculos(int id);
        IList<Tarjeta> GetTarjetas(int id);
    }
}