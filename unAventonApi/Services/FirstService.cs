using unAventonApi.Data;

namespace unAventonApi.Services
{
    public class FirstService : IFirstService
    {
        private readonly IUserRepository userRepo;

        public FirstService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        void IFirstService.SendEmail()
        {
            
        }
    }
}