using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;

namespace unAventonApi.Services.Interfaces
{
    public interface IAuthentificateService
    {
         ApiResponse<User> AuthentificateUser(UserCredentialsDTO userCredentials);
    }
}