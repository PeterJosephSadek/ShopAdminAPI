using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Entities.Products;
using ECommerceDashboard.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Repositoy
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
            if (collection != null)
            {
                await _context.AddAsync(collection);
            }
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

        public IQueryable<Collection> GetAll()
        {
            return  _context.Collections.OrderBy(p => p.Name);
        }

        public async Task<Collection?> GetById(int? id)
        {
            Collection? collection = await _context.Collections.FindAsync(id);
            return collection;
        }

        public  IQueryable<Product> GetProductsByCollectionId(int collectionId)
        {
            return  _context.Products
                     .Include(p => p.Category)
                     .Include(p => p.Collection)
                     .Where(p => p.Collection != null && p.Collection.Id == collectionId);
        }

        public async Task<int> Update(Collection collection)
        {
            _context.Collections.Update(collection);
            return await _context.SaveChangesAsync();
        }
    }
}
