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
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _unitOfWork.ProductRepository.GetAll().
                Select(product => new ProductToReturnDTO()
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

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int Id) 
        {
            Product product = _unitOfWork.ProductRepository.GetById(Id);

            if(product == null) return NotFound(new ApiResponse(404));

            ProductToReturnDTO Dto = new ProductToReturnDTO()
            {
                Id = Id,
                Name = product.Name,
                Category = product.Category?.Name ?? "No Category",
                CategoryId = product.Category?.Id ?? 0,
                Collection = product.Collection?.Name ?? "No Collection",
                CollectionId = product.Collection?.Id ?? 0,
                Description = product.Description ?? "No Description",
                Price = product.Price,
                Reviews = product.Reviews?.Select(r => new ReviewDto
                    {
                        CustomerName = r.CustomerName,
                        ProductId = r.ProductId,
                        Stars = r.Stars,
                        Text = r.Text,
                        Title = r.Title
                    }).ToList()
            };

            return Ok(Dto);
        }

        [HttpGet("byCategory")]
        public ActionResult<IQueryable<Product>> GetProductsByCategory([FromQuery] int CategoryId)
        {
            var products =  _unitOfWork.ProductRepository.GetAllByCategory(CategoryId);

            var Dtos = products.Select(product => new ProductToReturnDTO
            {
                Id = product.Id,
                Name = product.Name,
                Collection = product.Collection.Name ?? "No Collection",
                CollectionId = product.CollectionId,
                Category = product.Category.Name ?? "No Collection",
                CategoryId = product.CategoryId,
                Description = product.Description ?? "No Description",
                Price = product.Price,
            });

            return Ok(Dtos);
        }

        [HttpGet("byCollection")]
        public ActionResult<IQueryable<Product>> GetProductsByCollection([FromQuery] int CollectionId)
        {
            var products = _unitOfWork.ProductRepository.GetAllByCollection(CollectionId);

            var Dtos = products.Select(product => new ProductToReturnDTO
            {
                Id = product.Id,
                Name = product.Name,
                Collection = product.Collection.Name ?? "No Collection",
                CollectionId = product.CollectionId,
                Category = product.Category.Name ?? "No Collection",
                CategoryId = product.CategoryId,
                Description = product.Description ?? "No Description",
                Price = product.Price,
            });

            return Ok(Dtos);
        }

        [HttpGet("BySearch")]
        public ActionResult<IQueryable<Product>> GetProductsBySearch([FromQuery] string searchWord)
        {
            var products = _unitOfWork.ProductRepository.GetProductBySearch(searchWord);

            var Dtos = products.Select(product => new ProductToReturnDTO
            {
                Id = product.Id,
                Name = product.Name,
                Collection = product.Collection.Name ?? "No Collection",
                CollectionId = product.CollectionId,
                Category = product.Category.Name ?? "No Collection",
                CategoryId = product.CategoryId,
                Description = product.Description ?? "No Description",
                Price = product.Price,
            });

            return Ok(Dtos);
        }
    }
}
