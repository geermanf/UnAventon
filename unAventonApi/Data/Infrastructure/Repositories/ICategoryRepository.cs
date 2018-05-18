using System.Threading.Tasks;

namespace unAventonApi.Data
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Task<Category> GetCoolestCategory();
    }
}