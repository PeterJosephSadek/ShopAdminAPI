using System.ComponentModel.DataAnnotations;

namespace ECommerceDashboard.DAL.Entities.Orders
{
    public class Delivery
    {
        public int Id { get; set; }
        [Required]
        public string Region { get; set; }

        [Required]
        public double DeliveryFees { get; set; }

        public bool IsDefault { get; set; }
       /* public virtual ICollection<Order>? Orders { get; set; }*/
    }
}
