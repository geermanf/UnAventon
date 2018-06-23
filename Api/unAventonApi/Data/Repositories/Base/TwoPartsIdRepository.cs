using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace unAventonApi.Data.Repositories.Base
{
    public class TwoPartsIdRepository<TEntity> : ITwoPartsIdRepository<TEntity>
        where TEntity : class
    {
        public readonly UnAventonDbContext _dbContext;

        public TwoPartsIdRepository(UnAventonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetByIds(int idUser,int idViaje)
        {
            return _dbContext.Set<TEntity>()
                .Find(idUser,idViaje);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var ret = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return ret.Entity;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update<TEntity>(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int idUser,int idViaje)
        {
            var entity = _dbContext.Find<TEntity>(idUser,idViaje);
            _dbContext.Remove<TEntity>(entity);
            _dbContext.SaveChanges();
        }
    }
}