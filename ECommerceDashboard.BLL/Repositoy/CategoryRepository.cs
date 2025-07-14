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

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            return category;

        }

        public async Task<int> Update(Category category)
        {
            _context.Categories.Update(category);
            return await _context.SaveChangesAsync();
        }
    }
}
