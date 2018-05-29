using System;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : GenericController<IUserRepository, User>
    {
        public UserController(IUserRepository genericRepo) : base(genericRepo)
        {
        }

        [HttpPost("ListarPorEmail")]
        public IActionResult Get([FromBody]string email)
        {
            try
            {
                var response = this.genericRepo.GetByEmail(email).Result;

                // return BuildApiResponse.BuildOk();
                return Ok(response);
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al listar con id: " + email);
            }
        }


        [HttpGet("ListarVehiculos")]
        public IActionResult GetVehiculos(int id)
        {
            try
            {
                var response = this.genericRepo.GetVehiculos(id);

                // return BuildApiResponse.BuildOk();
                return Ok(response);
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al listar con id: " + id);
            }
        }

        [HttpGet("ListarTarjetas")]
        public IActionResult GetTarjetas(int id)
        {
            try
            {
                var response = this.genericRepo.GetTarjetas(id);

                // return BuildApiResponse.BuildOk();
                return Ok(response);
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al listar con id: " + id);
            }
        }
    }
}
