using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDashboard.DAL.Entities.Products
{
    public class Review
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public int Stars { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

    }
}
