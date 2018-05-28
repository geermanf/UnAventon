// using System.Diagnostics;
// using System.Threading.Tasks;
// using unAventonApi.Data.Entities;
// using Microsoft.AspNetCore.Mvc;
// using unAventonApi.Models;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using unAventonApi.Services.Base;
// using unAventonApi.Data;
// using unAventonApi.Data.DTOEntities;
// using unAventonApi.Services.Interfaces;
// using System;

// namespace unAventonApi.Controllers
// {
//     [Route("api/[controller]")]
//     public class TarjetaController : Controller
//     {
//         private readonly ITarjetaRepository tarjetaRepo;

//         public TarjetaController(ITarjetaRepository tarjetaRepo)
//         {
//             this.tarjetaRepo = tarjetaRepo;
//         }

//         [HttpPost("Registrar")]
//         public async Task<ApiResponse> Registrar(Tarjeta tarjeta)
//         {
//             var response = new Tarjeta();
//             try
//             {
//                 await this.tarjetaRepo.Create(tarjeta);

//                 return BuildApiResponse.BuildOk();
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk("Hubo un error al registrar el usuario");
//             }


//         }

//         [HttpGet("Listar")]
//         public ApiResponse<List<Tarjeta>> Get()
//         {
//             var response = new List<Tarjeta>();

//             try
//             {
//                 response = this.tarjetaRepo.GetAll().ToListAsync().Result;

//                 return BuildApiResponse.BuildOk<List<Tarjeta>>(response);
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk<List<Tarjeta>>(response, "Hubo un error al obtener los Tarjetas");
//             }



//         }

//         [HttpPost("Modificar")]
//         public ApiResponse Modificar(Tarjeta tarjeta)
//         {

//             try
//             {
//                 this.tarjetaRepo.Update(tarjeta.Id, tarjeta);

//                 return BuildApiResponse.BuildOk();
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk("Hubo un error al obtener los Tarjetas");
//             }



//         }

//         // GET
//         [HttpGet("ListarPorId")]
//         public ApiResponse<Tarjeta> Get(int id)
//         {

//             var response = new Tarjeta();

//             try
//             {
//                 response = this.tarjetaRepo.GetById(id).Result;


//                 return BuildApiResponse.BuildOk<Tarjeta>(response);
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk<Tarjeta>(response, "Hubo un error al obtener los Tarjetas");
//             }
//         }

//         // DELETE
//         [HttpPost("Borrar")]
//         public ApiResponse Delete(int id)
//         {
//             try
//             {
//                 this.tarjetaRepo.Delete(id);


//                 return BuildApiResponse.BuildOk();
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk("Hubo un error al borrar el Tarjetas");
//             }
//         }
//     }
// }
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class TarjetaController : GenericController<ITarjetaRepository, Tarjeta>
    {
        public IUserRepository userRepository { get; }

        public TarjetaController(ITarjetaRepository genericRepo, IUserRepository userRepository) : base(genericRepo)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("RegistrarEnUser")]
        public async Task<IActionResult> Registrar([FromBody] Tarjeta tarjeta, [FromQuery]int userId)
        {
            try
            {
                var user = await this.userRepository.GetById(userId);
                tarjeta.Usuario = user;
                user.Tarjetas.Add(tarjeta);
                await this.genericRepo.Create(tarjeta);

                // return BuildApiResponse.BuildOk();
                return Ok();
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk( "Hubo un error al registrar");
                return BadRequest("Hubo un error al registrar");
            }


        }
    }
}