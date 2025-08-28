using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        IQueryable<Product> GetProductsByCategoryId(int categoryId);
        Task<Category?> GetById(int? id);
        Task<int> Add(Category category);
        Task<int> Update(Category category);
        Task<int> Delete(int id);
    }
}
