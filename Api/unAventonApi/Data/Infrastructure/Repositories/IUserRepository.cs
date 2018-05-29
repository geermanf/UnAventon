using System.Collections.Generic;
using System.Threading.Tasks;
using unAventonApi.Data.DTOEntities;

namespace unAventonApi.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        IList<Vehiculo> GetVehiculos(int id);
        IList<Tarjeta> GetTarjetas(int id);
        User GetAllUserById(int id);

        // void CreateWithRel(TarjetaDTO tarjeta, int userId, User user);
    }
}