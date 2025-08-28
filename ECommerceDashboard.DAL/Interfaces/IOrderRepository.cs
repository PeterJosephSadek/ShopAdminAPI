using ECommerceDashboard.DAL.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
        Task<Order> GetById(int id);
        Task<int> Add(Order order);
        Task<int> Update(Order order);
        Task<int> Delete(int id);
    }
}
