using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        IQueryable<Product> GetAllByCategory(int categoryId);
        IQueryable<Product> GetAllByCollection(int collectionId);
        IQueryable<Product> GetProductBySearch(string searchWord);

        Task<Product> GetById(int? id);
        Task<int> Add(Product collection);
        Task<int> Update(Product collection);
        Task<int> Delete(int? id);
    }
}
