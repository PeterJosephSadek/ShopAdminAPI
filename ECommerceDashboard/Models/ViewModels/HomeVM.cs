using ECommerceDashboard.DAL.Entities.Orders;
using ECommerceDashboard.DAL.Entities.Products;

namespace ECommerceDashboard.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Product>? ProductsList { get; set; }
        public IEnumerable<Order>? Orders { get; set; }

        public double MonthIncome { get; set; }
        public double LastMonthIncome { get; set; }

        public double IncomeDiff { get; set; }

        public double AvgOrder { get; set; }
        public int ReviewsCount { get; set; }
    }
}
