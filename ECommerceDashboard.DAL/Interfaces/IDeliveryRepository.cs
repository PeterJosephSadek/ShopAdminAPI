using ECommerceDashboard.DAL.Entities.Orders;
using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Interfaces
{
    public interface IDeliveryRepository
    {
        IQueryable<Delivery> GetAll();
        Task<Delivery?> GetById(int? id);
        Task<int> Add(Delivery delivery);
        Task<int> Update(Delivery delivery);
        Task<int> Delete(int id);
    }
}
