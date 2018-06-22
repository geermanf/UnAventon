using System.Collections.Generic;
using System.Threading.Tasks;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;

namespace unAventonApi.Data
{
    public interface IViajeRepository : IGenericRepository<Viaje>
    {
        Viaje GetAllById(int id);
    }
}