using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ECommerceDashboard.DAL.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Collection")]
        public int CollectionId { get; set; }
        public Collection? Collection { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //public ICollection<ProductImage> Images { get; set; }
        public ICollection<Review>? Reviews { get; set; }


    }
}
