using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IQueryable<Product> GetAllByCategory(int categoryId);
        IQueryable<Product> GetAllByCollection(int collectionId);

        IQueryable<Product> GetProductBySearch(string searchWord);

        Product GetById(int id);
        int Add(Product collection);
        int Update(Product collection);
        int Delete(int id);
    }
}
