using System.Threading.Tasks;
using unAventonApi.Data.DTOEntities;

namespace unAventonApi.Data
{
    public interface ITarjetaRepository : IGenericRepository<Tarjeta>
    {
        Tarjeta CreateWithRel(TarjetaDTO tarjeta, int userId);
    }
}