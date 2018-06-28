using System.Linq;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Entities.TablasIntermedias;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class ViajerosRepository : TwoPartsIdRepository<Viajeros>, IViajerosRepository
    {
        public ViajerosRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

        public IQueryable<Viajeros> GetByIdViaje(int idViaje)
        {
            return _dbContext.Set<Viajeros>().Include(x => x.User).Include(x => x.Viaje).Where(p => p.ViajeId == idViaje)
            .Select(v => new Viajeros(){
                ViajeId = v.ViajeId,
                UserId = v.UserId,
                User = new User() { Nombre = v.User.Nombre, Apellido = v.User.Apellido, Email = v.User.Email, FotoPerfil = v.User.FotoPerfil, Id = v.User.Id }

            });
        }

    }
}