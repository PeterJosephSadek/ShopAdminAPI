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

        public ActionResult<IEnumerable<Collection>> Get()
        {
            var collections = _unitOfWork.CollectionRepository.GetAll();
            return Ok(collections);
        }

        /*[HttpGet("Products/{id}")]

        public ActionResult<IEnumerable<Collection>> GetCollectionProducts(int id)
        {
            
        }*/

    }
}
