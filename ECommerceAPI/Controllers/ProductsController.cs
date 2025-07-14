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

        [HttpGet("Products")]
        public ActionResult<IEnumerable<Product>> AllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("Products/{id}")]
        public ActionResult<Product> GetById(int Id) 
        {
            Product product = _unitOfWork.ProductRepository.GetById(Id);
            return Ok(product);
        }

    }
}
