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
    }
}
