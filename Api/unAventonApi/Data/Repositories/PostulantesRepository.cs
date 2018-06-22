using System.Linq;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Entities.TablasIntermedias;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class PostulantesRepository : GenericRepository<Postulantes>, IPostulantesRepository
    {

        public PostulantesRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }
        public void DeleteByIds(int idPostulante, int idViaje)
        {
            var entity = _dbContext.Set<Postulantes>().Find(idPostulante,idViaje);
            _dbContext.Remove<Postulantes>(entity);
            _dbContext.SaveChanges();
        }

        public Postulantes GetByIds(int idPostulante, int idViaje)
        {
            var entity = _dbContext.Set<Postulantes>().Find(idPostulante,idViaje);
            return entity;
        }
    }
}