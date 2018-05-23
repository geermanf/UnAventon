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

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthentificateController : Controller
    {
        private readonly IAuthentificateService authService;

        public AuthentificateController(IAuthentificateService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        public ApiResponse Authentificate(string email, string password)
        {
            var userCredentials = new UserCredentialsDTO {
                Email = email,
                Password = password
            };
            var response = this.authService.AuthentificateUser(userCredentials);
            return response;
        }
    }
}
