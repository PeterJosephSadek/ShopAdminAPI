using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Interfaces
{
    public interface ICollectionService
    {
        IEnumerable<Collection> GetAll();
        IEnumerable<Product> GetProductsByCollectionId(int collectionId);

        Task<Collection?> GetById(int? id);
        Task<int> Add(Collection collection);
        Task<int> Update(Collection collection);
        Task<int> SoftDelete(int id);
    }
}
