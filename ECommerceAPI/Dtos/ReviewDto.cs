
using ECommerceDashboard.DAL.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Dtos
{
    public class ReviewDto
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public int Stars { get; set; }
        public int ProductId { get; set; }
    }
}
