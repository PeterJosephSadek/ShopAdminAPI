using ECommerceDashboard.DAL.Interfaces;
using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Repositoy
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Order order)
        {
            order.CreatedOn = DateTime.Now;
            order.TotalPrice = order.OrderItems.Sum(o=>o.Price) * order.OrderItems.Sum(o => o.Quantity);
            await _context.Orders.AddAsync(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order != null)
            {
                Order.IsDeleted = true;
            }
            return await _context.SaveChangesAsync();

        }

        public IQueryable<Order> GetAll()
        {
            return _context.Orders
                  .Include(o => o.Status)
                 .Include(o => o.Delivery)
                 .Include(o => o.OrderItems)
                 .OrderBy(o => o.Status);
        }

        public async Task<Order?> GetById(int id)
        {
            Order? Order = await _context.Orders
                  .Include(o => o.Status)
                  .Include(o => o.Delivery)
                  .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                  .FirstOrDefaultAsync(o => o.Id == id);


            return (Order);
        }

        public async Task <int> Update(Order order)
        {
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync();
        }
    }
}
