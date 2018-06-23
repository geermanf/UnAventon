using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data
{
    public class ViajeRepository : GenericRepository<Viaje>, IViajeRepository
    {
        public ViajeRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

        public Viaje GetAllById(int id)
        {
            var viaje = _dbContext.Viaje
                    .Include(v => v.TipoViaje)
                    .Include(v => v.Vehiculo)
                    .Include(v => v.Postulantes).ThenInclude(p => p.User)
                    .Include(v => v.Viajeros).ThenInclude(p => p.User)
                    .Include(v => v.Creador)
                    .FirstOrDefault(x => x.Id == id);
            return viaje;
        }

        public new IQueryable<Viaje> GetAll()
        {
            var viajes = _dbContext.Viaje
                    .Include(v => v.TipoViaje)
                    .Include(v => v.Vehiculo)
                    .Include(v => v.Postulantes).ThenInclude(p => p.User)
                    .Include(v => v.Viajeros).ThenInclude(p => p.User)
                    .Include(v => v.Creador).AsNoTracking();
            return viajes;
        }
    }
}