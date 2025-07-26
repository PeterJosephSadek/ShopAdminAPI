using ECommerceDashboard.DAL.Entities.Products;
using System.ComponentModel.DataAnnotations;

namespace ECommerceDashboard.Models.ViewModels
{
    public class CreateOrderViewModel
    {
        // Order Information
        [Required(ErrorMessage = "Customer name is required")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Address Location")]
        public string? AddressLocation { get; set; }

        [Display(Name = "Comment")]
        public string? Comment { get; set; }

        [Required]
        [Display(Name = "Delivery Method")]
        public int DeliveryId { get; set; }

        // Order Items (will be populated via JavaScript)
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();

        // Products available for selection
        public IEnumerable<Product> AvailableProducts { get; set; } = new List<Product>();

        // Calculated total
        public double TotalPrice { get; set; }
    }

    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total => Price * Quantity;
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string? Description { get; set; }
    }
}
