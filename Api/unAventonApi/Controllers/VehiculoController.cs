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
//     public class VehiculoController : Controller
//     {
//         private readonly IVehiculoRepository vehiculoRepo;

//         public VehiculoController(IVehiculoRepository vehiculoRepo)
//         {
//             this.vehiculoRepo = vehiculoRepo;
//         }

//         [HttpPost("Registrar")]
//         public async Task<ApiResponse> Registrar(Vehiculo vehiculo)
//         {
//             try
//             {
//                 await this.vehiculoRepo.Create(vehiculo);

//                 return BuildApiResponse.BuildOk();
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk( "Hubo un error al registrar el usuario");
//             }


//         }

//         [HttpGet("Listar")]
//         public ApiResponse<List<Vehiculo>> Get()
//         {
//             var response = new List<Vehiculo>();

//             try
//             {
//                 response = this.vehiculoRepo.GetAll().ToListAsync().Result;

//                 return BuildApiResponse.BuildOk<List<Vehiculo>>(response);
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk<List<Vehiculo>>(response, "Hubo un error al obtener los vehiculos");
//             }



//         }

//         [HttpPost("Modificar")]
//         public ApiResponse Modificar(Vehiculo vehiculo)
//         {
//             var response = new Vehiculo();

//             try
//             {
//                 this.vehiculoRepo.Update(vehiculo.Id, vehiculo);

//                 return BuildApiResponse.BuildOk();
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk("Hubo un error al obtener los vehiculos");
//             }



//         }

//         // GET
//         [HttpGet("ListarPorId")]
//         public ApiResponse<Vehiculo> Get(int id)
//         {

//             var response = new Vehiculo();

//             try
//             {
//                 response = this.vehiculoRepo.GetById(id).Result;


//                 return BuildApiResponse.BuildOk<Vehiculo>(response);
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk<Vehiculo>(response, "Hubo un error al obtener los vehiculos");
//             }
//         }

//         // DELETE
//         [HttpPost("Borrar")]
//         public ApiResponse Delete(int id)
//         {
//             try
//             {
//                 this.vehiculoRepo.Delete(id);


//                 return BuildApiResponse.BuildOk();
//             }
//             catch (Exception)
//             {
//                 return BuildApiResponse.BuildNotOk("Hubo un error al borrar el vehiculos");
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
    public class VehiculoController : GenericController<IVehiculoRepository, Vehiculo>
    {
        public IUserRepository userRepository { get; }

        public VehiculoController(IVehiculoRepository genericRepo, IUserRepository userRepository) : base(genericRepo)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("RegistrarEnUser")]
        public async Task<IActionResult> Registrar([FromBody] Vehiculo vehiculo, [FromQuery]int userId)
        {
            try
            {
                var user = await this.userRepository.GetById(userId);
                vehiculo.Usuario = user;
                user.Vehiculos.Add(vehiculo);
                await this.genericRepo.Create(vehiculo);

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
