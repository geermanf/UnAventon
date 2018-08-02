using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.DTOEntities;
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

        public User GetAllUserById(int id)
        {
            var user = _dbContext.Users
                    .Include(u => u.Tarjetas).ThenInclude(t => t.Banco)
                    .Include(u => u.Tarjetas).ThenInclude(t => t.Tipo)
                    .Include(u => u.Vehiculos)
                    .Include(u => u.ViajesCreados)
                    .Include(u => u.ViajesPendientes).ThenInclude(t => t.Viaje).ThenInclude(v => v.DiasDeViaje)
                    .Include(u => u.ViajesRealizados)
                    .Include(u => u.CalificacionesRecibidas).ThenInclude(c => c.Rol)
                    .Include(u => u.CalificacionesRecibidas).ThenInclude(c => c.Puntuacion)
                    .Include(u => u.CalificacionesRecibidas).ThenInclude(c => c.UsuarioPuntuador)
                    .Include(u => u.CalificacionesBrindadas).ThenInclude(c => c.Rol)
                    .Include(u => u.CalificacionesBrindadas).ThenInclude(c => c.Puntuacion)
                    .Include(u => u.CalificacionesBrindadas).ThenInclude(c => c.UsuarioCalificado)
                    .Include(u => u.Pagos).ThenInclude(p => p.Tarjeta)
                    .Include(u => u.Pagos).ThenInclude(p => p.Viaje).ThenInclude(v => v.DiasDeViaje)
                    .FirstOrDefault(x => x.Id == id);
            return user;
        }

        public IList<Vehiculo> GetVehiculos(int id)
        {
            var user = this.GetAllUserById(id);
            return user.Vehiculos;
        }
        public IList<Tarjeta> GetTarjetas(int id)
        {
            var user = this.GetAllUserById(id);
            return user.Tarjetas;
        }


        // public void CreateWithRel(TarjetaDTO tarjeta, int userId, User user)
        // {
        //     var card = new Tarjeta()
        //     {
        //         NumeroTarjeta = tarjeta.NumeroTarjeta,
        //         NombreTitular = tarjeta.NombreTitular,
        //         FechaVencimiento = tarjeta.FechaVencimiento
        //     };
        //     card.Banco = _dbContext.Banco.Find(tarjeta.Banco);
        //     card.Tipo = _dbContext.TipoTarjeta.Find(tarjeta.Tipo);
        //     user.Tarjetas.Add(card);

        //     _dbContext.Update<User>(user);
        // }
    }
}