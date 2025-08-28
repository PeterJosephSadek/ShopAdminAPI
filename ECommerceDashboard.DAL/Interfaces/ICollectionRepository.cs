using ECommerceDashboard.DAL.Entities.Orders;
using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Interfaces
{
    public interface ICollectionRepository
    {
        IQueryable<Collection> GetAll();
        IQueryable<Product> GetProductsByCollectionId(int collectionId);

        Task<Collection?> GetById(int? id);
        Task<int> Add(Collection collection);
        Task<int> Update(Collection collection);
        Task<int> Delete(int id);
    }
}
