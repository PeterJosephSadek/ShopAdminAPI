using ECommerceDashboard.DAL.Interfaces;
using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Repositoy
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ECommerceDbContext _context;

        public ReviewRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Review review)
        {
            try
            {
                int MaxStarsNumber = 5;
                if (review.Stars > MaxStarsNumber) review.Stars = MaxStarsNumber;
                if (review.Stars < 0) review.Stars = 0;

                review.CreatedOn = DateTime.Now;
                await _context.Reviews.AddAsync(review);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public async Task<int> Delete(int id)
        {
            var Review = await _context.Reviews.FindAsync(id);
            if (Review != null)
            {
                Review.IsDeleted = true;
            }
            return await _context.SaveChangesAsync();

        }

        public IQueryable<Review> GetAll()
        {
            var Reviews =  _context.Reviews
            .Include(p => p.Product);

            return Reviews;
        }

        public async Task<Review> GetById(int? id)
        {
            Review? Review = await _context.Reviews
             .Include(p => p.Product)
             .FirstOrDefaultAsync(m => m.Id == id);

            return (Review);
        }

        public async Task<int> GetReviewsCountAsync()
        {
            return await _context.Reviews.CountAsync();
        }

        public async Task<int> Update(Review review)
        {
            _context.Reviews.Update(review);
            return await _context.SaveChangesAsync();
        }
    }
}
