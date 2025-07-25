﻿using ECommerceDashboard.DAL.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDashboard.DAL.Entities.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        public double Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
