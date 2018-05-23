using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }
    }
}