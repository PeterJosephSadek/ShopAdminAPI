using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Repositoy
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ECommerceDbContext _context;

        public DeliveryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Delivery delivery)
        {
            if (delivery.IsDefault)
            {
                // Update all records to set IsDefault to false
                await _context.Database.ExecuteSqlRawAsync("UPDATE Deliveries SET IsDefault = 'false'");
            }

            await _context.Deliveries.AddAsync(delivery);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var Delivery = await _context.Deliveries.FindAsync(id);
            if (Delivery != null)
            {
                _context.Remove(Delivery);
            }
           return  await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Delivery>> GetAll()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Delivery> GetById(int id)
        {
            return await _context.Deliveries.FindAsync(id);
        }

        public async Task<int> Update(Delivery delivery)
        {
            if (delivery.IsDefault)
            {
                // Update all records to set IsDefault to false
                await _context.Database.ExecuteSqlRawAsync("UPDATE Deliveries SET IsDefault = 'false'");
            }

            _context.Deliveries.Update(delivery);
            return await _context.SaveChangesAsync();
        }
    }
}
