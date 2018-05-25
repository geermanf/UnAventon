using System.Diagnostics;
using System.Threading.Tasks;
using unAventonApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Services.Base;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Services.Interfaces;
using System;
using Microsoft.AspNetCore.Cors;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepo;

        public UserController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpPost("Registrar")]
        public async Task<ApiResponse<User>> Registrar(UserDTO user)
        {
            var data = new User
            {
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                FechaNacimiento = user.FechaNacimiento,
                Password = user.Password,
                Email = user.Email
            };
            try
            {
                await this.userRepo.Create(data);

                return BuildApiResponse.BuildOk<User>(data);
            }
            catch (Exception)
            {
                return BuildApiResponse.BuildNotOk<User>(data, "Hubo un error al registrar el usuario");
            }


        }
        [HttpGet("GetAll")]
        public ApiResponse<List<User>> Get()
        {
            var response = this.userRepo.GetAll();
            try
            {
                return BuildApiResponse.BuildOk<List<User>>(response.ToListAsync().Result);
            }
            catch (Exception)
            {
                return BuildApiResponse.BuildNotOk<List<User>>(response.ToListAsync().Result, "Hubo un error al obtener los usuarios");
            }

        }
    }
}
