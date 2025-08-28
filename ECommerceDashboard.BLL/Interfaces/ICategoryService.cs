using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Interfaces
{
    internal interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Product> GetProductsByCollectionId(int categoryId);

        Task<Category?> GetById(int? id);
        Task<int> Add(Category category);
        Task<int> Update(Category category);
        Task<int> SoftDelete(int id);
    }
}
