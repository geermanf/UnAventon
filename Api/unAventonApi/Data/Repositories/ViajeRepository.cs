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
                    .Include(x => x.Postulantes)
                    .Include(x => x.Viajeros)
                    .FirstOrDefault(x => x.Id == id);
            return viaje;
        }
    }
}