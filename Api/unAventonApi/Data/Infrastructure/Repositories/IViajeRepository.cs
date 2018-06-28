using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;

namespace unAventonApi.Data
{
    public interface IViajeRepository : IGenericRepository<Viaje>
    {
        Viaje GetAllById(int id);

        List<Viaje> GetByVehiculoId(int vehiculoId);

        IQueryable<Object> GetAllNotIncludes();

        Object GetByIdNotIncludes(int id);
    }
}