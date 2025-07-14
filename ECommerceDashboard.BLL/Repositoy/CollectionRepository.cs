using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Repositoy
{

    public class CollectionRepository : ICollectionRepository
    {
        private readonly ECommerceDbContext _context;

        public CollectionRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Collection collection)
        {
            collection.CreatedOn = DateTime.Now;
             await _context.Collections.AddAsync(collection);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Collection? collection =  _context.Collections.Find(id);
            if (collection != null)
            {
                collection.IsDeleted = true;
            }
            return await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Collection>> GetAll()
        {
            return await _context.Collections.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Collection> GetById(int id)
        {
            Collection? collection = await _context.Collections.FindAsync(id);
            return collection;
        }

        public async Task<int> Update(Collection collection)
        {
            _context.Collections.Update(collection);
            return await _context.SaveChangesAsync();
        }
    }
}
