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
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            Category Category = await _unitOfWork.CategoryRepository.GetById(Id);
            if (Category == null) return NotFound(new ApiResponse(404));
            return Ok(Category);
        }


        // GET: api/categories/{categoryId}/items
        [HttpGet("{categoryId}/items")]
        public async Task<IActionResult> GetItemsForCategory(int categoryId)
        {
            // Logic to get items belonging to the collection
            var products = await _unitOfWork.CategoryRepository.GetProductsByCategoryId(categoryId);

            var Dtos = products.Select(product => new ProductToReturnDTO
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
