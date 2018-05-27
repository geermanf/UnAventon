using System.Threading.Tasks;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;
using unAventonApi.Services.Interfaces;

namespace unAventonApi.Services.Base
{
    public class AuthentificateService : IAuthentificateService
    {
        private readonly IUserRepository userRepo;

        public AuthentificateService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public ApiResponse<User>  AuthentificateUser(UserCredentialsDTO userCredentials)
        {
            var user = this.userRepo.GetByEmail(userCredentials.Email).Result;

            if (user == null)
            {
                return BuildApiResponse.BuildNotOk<User>(null,"Email no registrado en el sistema");
            }
            else if (user.Email == userCredentials.Email && user.Password == userCredentials.Password)
            {
                return BuildApiResponse.BuildOk<User>(user);

            }
            else
            {
                return BuildApiResponse.BuildNotOk<User>(null,"Email o Password incorrecto");
            }



        }
    }
}