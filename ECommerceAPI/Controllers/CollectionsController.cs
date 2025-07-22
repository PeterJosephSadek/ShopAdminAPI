using ECommerceAPI.Dtos;
using ECommerceAPI.Errors;
using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Collection>> GetAll()
        {
            var collections = _unitOfWork.CollectionRepository.GetAll();
            return Ok(collections);
        }

        [HttpGet("{id}")]
        public ActionResult<Collection> GetById(int id)
        { 
            var collection = _unitOfWork.CollectionRepository.GetById(id);

            if (collection == null) return NotFound(new ApiResponse(404));

            return Ok(collection);
            
        }


        // GET: api/collections/{collectionId}/items
        [HttpGet("{collectionId}/items")]
        public async Task<IActionResult> GetItemsForCollection(int collectionId)
        {
            var products = await _unitOfWork.CollectionRepository.GetProductsByCollectionId(collectionId);

            var Dtos= products.Select(product => new ProductToReturnDTO
             {
                 Id = product.Id,
                 Name = product.Name,
                 Category = product.Category?.Name ?? "No Category",
                 CategoryId = product.Category?.Id ?? 0,
                 Collection = product.Collection?.Name ?? "No Collection",
                 CollectionId = product.Collection?.Id ?? 0,
                 Description = product.Description ?? "No Description",
                 Price = product.Price,
             });
            
             return Ok(Dtos);
        }

    }
}
