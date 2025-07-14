using ECommerceDashboard.DAL.Entities.Orders;
using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<IEnumerable<Delivery>> GetAll();
        Task<Delivery> GetById(int id);
        Task<int> Add(Delivery delivery);
        Task<int> Update(Delivery delivery);
        Task<int> Delete(int id);
    }
}
