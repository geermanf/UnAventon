using System.Linq;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data.Repositories
{
    public class TarjetaRepository : GenericRepository<Tarjeta>, ITarjetaRepository
    {
        public TarjetaRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

        public Tarjeta CreateWithRel(TarjetaDTO tarjeta, int userId)
        {
            var card = new Tarjeta()
            {
                NumeroTarjeta = tarjeta.NumeroTarjeta,
                NombreTitular = tarjeta.NombreTitular,
                FechaVencimiento = tarjeta.FechaVencimiento
            };
            card.Banco = _dbContext.Banco.Find(tarjeta.Banco);
            card.Tipo = _dbContext.TipoTarjeta.Find(tarjeta.Tipo);

            var ret = _dbContext.Add<Tarjeta>(card);
            _dbContext.SaveChanges();

            return ret.Entity;
        }

    }
}