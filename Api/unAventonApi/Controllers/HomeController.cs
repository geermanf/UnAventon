using System.Diagnostics;
using System.Threading.Tasks;
using unAventonApi.Data;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Services;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IUserRepository userRepo;

        public HomeController(ICategoryRepository repository, IUserRepository userRepo, IFirstService fservice)
        {
            _repository = repository;
            this.userRepo = userRepo;
        }

        [HttpGet("index")]
        public async Task<Category> Index()
        {

            var category = new Category
            {
                Description = "first category - very cool description",
                Name = "First category"
            };

            var category2 = new Category
            {
                Description = "first 4123123category - very cool description",
                Name = "First ca124123123tegory"
            };

            var category3 = new Category
            {
                Description = "first ca1412312tegory - very cool description",
                Name = "First cate412312gory"
            };
            await _repository.Create(category);

            await _repository.Create(category2);
            await _repository.Create(category3);

            var coolestCategory = await _repository.GetCoolestCategory();

            return coolestCategory;
        }

        [HttpGet("GetAll")]
        public async Task<List<Category>> GetAll()
        {
            return await _repository.GetAll().ToListAsync();
        }

        [HttpGet("CrearUsers")]
        public async Task<List<User>> CrearUsers()
        {
            var category = new Category
            {
                Description = "first category - very cool description",
                Name = "First category"
            };

            var u1 = new User
            {
                Name = "user 1",
                Category = category
            };

                        var u2 = new User
            {
                Name = "user 2",
                Category = category
            };


            await this.userRepo.Create(u1);

            await this.userRepo.Create(u2);

            return null;

        }

        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            return await userRepo.GetAll().ToListAsync();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
