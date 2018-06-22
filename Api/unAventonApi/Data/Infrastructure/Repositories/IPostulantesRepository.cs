using System.Collections.Generic;
using System.Threading.Tasks;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Entities.TablasIntermedias;

namespace unAventonApi.Data
{
    public interface IPostulantesRepository : IGenericRepository<Postulantes>
    {
        void DeleteByIds(int idPostulante, int idViaje);
        Postulantes GetByIds(int idPostulante, int idViaje);
    }
}