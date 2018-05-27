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
    }
}
