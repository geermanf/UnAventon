using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Entities.TablasIntermedias;

namespace unAventonApi.Data
{
    public interface IPostulantesRepository : ITwoPartsIdRepository<Postulantes>
    {
        IQueryable<Postulantes> GetByIdViaje(int idViaje);
    }
}