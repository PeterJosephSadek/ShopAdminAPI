using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Entities.Products;
using ECommerceDashboard.DAL.Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDashboard.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<int> Add(Category category)
        {
            category.CreatedOn = DateTime.Now;

            return _unitOfWork.CategoryRepository.Add(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        public Task<Category?> GetById(int? id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);
        }

        public IEnumerable<Product> GetProductsByCollectionId(int categoryId)
        {
            return _unitOfWork.CategoryRepository.GetProductsByCategoryId(categoryId);
        }

        public async Task<int> SoftDelete(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(id);
            if (category == null)
                return 0;

            category.IsDeleted = true;

            return await _unitOfWork.CategoryRepository.Update(category);
        }
        public Task<int> Update(Category category)
        {
            return _unitOfWork.CategoryRepository.Update(category);
        }
    }
}
