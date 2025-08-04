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


    }
}
