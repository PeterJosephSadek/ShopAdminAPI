using ECommerceDashboard.DAL.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Dtos
{
    public class CreateOrderDto
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? AddressLocation { get; set; }
        public string? Comment { get; set; }
        public int DeliveryId { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }

    }
}
