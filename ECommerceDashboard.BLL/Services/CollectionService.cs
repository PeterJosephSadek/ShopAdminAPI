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

    public class CollectionService : ICollectionService
    {
        private readonly UnitOfWork _unitOfWork;

        public CollectionService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<int> Add(Collection collection)
        {
            collection.CreatedOn = DateTime.Now;
            return _unitOfWork.CollectionRepository.Add(collection);
        }

        public IEnumerable<Collection> GetAll()
        {
            return _unitOfWork.CollectionRepository.GetAll();
        }

        public Task<Collection?> GetById(int? id)
        {
            return _unitOfWork.CollectionRepository.GetById(id);
        }

        public IEnumerable<Product> GetProductsByCollectionId(int collectionId)
        {
           return _unitOfWork.CollectionRepository.GetProductsByCollectionId(collectionId);
        }

        public async Task<int> SoftDelete(int id)
        {
          var collection = await _unitOfWork.CollectionRepository.GetById(id);
            if (collection == null)
                return 0;

            collection.IsDeleted = true;

           return await _unitOfWork.CollectionRepository.Update(collection);
        }

        public Task<int> Update(Collection collection)
        {
            return _unitOfWork.CollectionRepository.Update(collection);
        }
    }
}
