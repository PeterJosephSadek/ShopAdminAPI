using ECommerceDashboard.DAL.Entities.Orders;
using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Interfaces
{
    public interface ICollectionRepository
    {
        Task<IEnumerable<Collection>> GetAll();
        Task<Collection> GetById(int id);
        Task<int> Add(Collection collection);
        Task<int> Update(Collection collection);
        Task<int> Delete(int id);
    }
}
