using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;
using unAventonApi.Data.Entities;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class TipoTarjetaController : GenericController<ITipoTarjetaRepository, TipoTarjeta>
    {

        public TipoTarjetaController(ITipoTarjetaRepository genericRepo) : base(genericRepo)
        {}
    }
}
