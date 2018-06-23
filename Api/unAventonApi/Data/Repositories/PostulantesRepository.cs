using System.Linq;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Entities.TablasIntermedias;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class PostulantesRepository : TwoPartsIdRepository<Postulantes>, IPostulantesRepository
    {

        public PostulantesRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

        public IQueryable<Postulantes> GetByIdViaje(int idViaje)
        {
            return _dbContext.Set<Postulantes>().Where(p => p.ViajeId == idViaje);
        }
    }
}