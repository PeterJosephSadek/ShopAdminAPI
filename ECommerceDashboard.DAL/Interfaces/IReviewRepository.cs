using ECommerceDashboard.DAL.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.DAL.Interfaces
{
    public interface IReviewRepository
    {
        IQueryable<Review> GetAll();

        Task<Review> GetById(int? id);
        Task<int> Add(Review review);
        Task<int> Update(Review review);
        Task<int> Delete(int id);
        Task<int> GetReviewsCountAsync();
    }
}
