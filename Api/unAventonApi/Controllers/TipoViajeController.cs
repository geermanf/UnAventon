using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;
using unAventonApi.Data.Entities;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class TipoViajeController : GenericController<ITipoViajeRepository, TipoViaje>
    {

        public TipoViajeController(ITipoViajeRepository genericRepo) : base(genericRepo)
        {}
    }
}
