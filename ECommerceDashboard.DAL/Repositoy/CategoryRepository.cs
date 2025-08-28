
using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Entities.Products;
using ECommerceDashboard.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Repositoy
{

    public class CategoryRepository : ICategoryRepository
    {
        readonly private ECommerceDbContext _context;

        public CategoryRepository (ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Category category)
        {
            if (category != null) 
            {
              await _context.AddAsync(category);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            if (category != null) 
            {
                category.IsDeleted = true;
            }
            return await _context.SaveChangesAsync();
        }

        public IQueryable<Category> GetAll()
        {
            return  _context.Categories;
        }

        public async Task<Category?> GetById(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public IQueryable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Products
                     .Include(p => p.Category)
                     .Include(p => p.Collection)
                     .Where(p => p.Collection != null && p.Collection.Id == categoryId);
        }

        public async Task<int> Update(Category category)
        {
            _context.Categories.Update(category);
            return await _context.SaveChangesAsync();
        }

    }
}
