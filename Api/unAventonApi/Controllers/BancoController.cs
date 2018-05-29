using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;
using unAventonApi.Data.Entities;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class BancoController : GenericController<IBancoRepository, Banco>
    {

        public BancoController(IBancoRepository genericRepo) : base(genericRepo)
        {}
    }
}
