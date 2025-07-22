using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDashboard.DAL.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public string? AddressLocation { get; set; }
        public double TotalPrice { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey("Delivery")]
        public int DeliveryId { get; set; }
        public Delivery? Delivery { get; set; }
        public Status? Status { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }


    }
}
