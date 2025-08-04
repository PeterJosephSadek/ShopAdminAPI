using ECommerceAPI.Dtos;
using ECommerceAPI.Errors;
using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Entities.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public ActionResult Post([FromBody] ReviewDto Dto)
        {
            Review review = new Review()
            {
                CustomerName = Dto.CustomerName,
                ProductId = Dto.ProductId,
                Stars = Dto.Stars,
                Text = Dto.Text,
                Title = Dto.Title,
            };

           Task<int> respond = _unitOfWork.ReviewRepository.Add(review);
            if (respond.Result == 0) 
            {
                return NotFound(new { message = "Product not found." });
            }
            else return Ok();

        }

    }
}
