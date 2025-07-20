using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
        Task<Category> GetById(int id);
        Task<int> Add(Category category);
        Task<int> Update(Category category);
        Task<int> Delete(int id);
    }
}
