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
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Product product)
        {
            product.CreatedOn = DateTime.Now;
            await _context.Products.AddAsync(product);
            return  _context.SaveChanges();
        }

        public async Task<int> Delete(int? id)
        {
            Product? Product = await _context.Products.FindAsync(id);
            if (Product != null)
            {
                Product.IsDeleted = true;
            }
            return _context.SaveChanges();
        }

        public IQueryable<Product> GetAll()
        {
            var products = (IQueryable<Product>) _context.Products
                .Include(p => p.Category)
                .Include(p => p.Collection)
                .Include(p => p.Reviews)
                .OrderBy(p => p.Name);

            return products;
        }

        public IQueryable<Product> GetAllByCategory(int categoryId)
        {
            return _context.Products
                           .Where(p => p.CategoryId == categoryId);
        }

        public IQueryable<Product> GetAllByCollection(int collectionId)
        {
            return _context.Products
               .Where(p => p.CollectionId == collectionId)
               .Include(p => p.Category)
               .Include(p => p.Collection);

        }

        public async Task<Product?> GetById(int? id)
        {
            Product? product = await _context.Products
             .Include(p => p.Category)
             .Include(p => p.Collection)
             .Include(p => p.Reviews)
             .FirstOrDefaultAsync(m => m.Id == id);

            return (product);
        }

        public IQueryable<Product> GetProductBySearch(string searchWord)
        {
            return _context.Products.Where(p => p.Name.Contains(searchWord))
                .Include(p => p.Category)
                .Include(p => p.Collection);

        }

        public async Task<int> Update(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync();
        }
    }
}
