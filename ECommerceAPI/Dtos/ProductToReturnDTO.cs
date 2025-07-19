using ECommerceDashboard.DAL.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Dtos
{
    public class ProductToReturnDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public int CollectionId { get; set; }
        public string? Collection { get; set; }

        public int CategoryId { get; set; }
        public string? Category { get; set; }
    }
}
