using System.Threading.Tasks;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;

namespace unAventonApi.Services.Interfaces
{
    public interface IAuthentificateService
    {
         ApiResponse AuthentificateUser(UserCredentialsDTO userCredentials);
    }
}