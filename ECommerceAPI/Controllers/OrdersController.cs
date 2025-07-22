using ECommerceAPI.Dtos;
using ECommerceAPI.Errors;
using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Entities.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderDto RequestOrder)
        {
            try
            {
                Order order = new Order()
                {
                    CustomerName = RequestOrder.CustomerName,
                    Address = RequestOrder.Address,
                    AddressLocation = RequestOrder.AddressLocation,
                    Comment = RequestOrder.Comment,
                    DeliveryId = RequestOrder.DeliveryId,
                    OrderItems = RequestOrder.OrderItems,
                    PhoneNumber = RequestOrder.PhoneNumber,
                };
                int response = await _unitOfWork.OrderRepository.Add(order);
                return Ok($"Order Created, Your response :{response}");
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400,"Bad Request, Order Not Created"));
            }

          
        }
    }
}
