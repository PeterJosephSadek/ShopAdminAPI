using System.ComponentModel.DataAnnotations;

namespace ECommerceDashboard.DAL.Entities.Products
{
    public class Collection
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Product>? Products { get; set; }

    }
}
