using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace unAventonApi.Data
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
            
        }

        public async Task<Category> GetCoolestCategory()
        {
            return await GetAll()
                .OrderByDescending(c => c.Name)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Category>> All()
        {
            return await GetAll().ToListAsync();
        }
    }
}