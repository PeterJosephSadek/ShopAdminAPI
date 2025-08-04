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
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public int Add(Product product)
        {
            product.CreatedOn = DateTime.Now;
            _context.Products.AddAsync(product);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            Product? Product =  _context.Products.Find(id);
            if (Product != null)
            {
                Product.IsDeleted = true;
            }
            return _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = _context.Products
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

        public Product GetById(int id)
        {
            Product? product = _context.Products
             .Include(p => p.Category)
             .Include(p => p.Collection)
             .Include(p => p.Reviews)
             .Where(m => m.Id == id)
             .FirstOrDefault();

            return (product);
        }

        public IQueryable<Product> GetProductBySearch(string searchWord)
        {
            return _context.Products.Where(p => p.Name.Contains(searchWord))
                .Include(p => p.Category)
                .Include(p => p.Collection);

        }

        public int Update(Product product)
        {
            _context.Products.Update(product);
            return _context.SaveChanges();
        }
    }
}
