using System.Diagnostics;
using ECommerceDashboard.Models.ViewModels;
using ECommerceDashboard.DAL.Entities.Orders;
using Microsoft.AspNetCore.Mvc;
using ECommerceDashboard.Models;
using ECommerceDashboard.DAL.Interfaces;

namespace ECommerceDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var Orders =  _unitOfWork.OrderRepository.GetAll();

            var ProductsList = _unitOfWork.ProductRepository.GetAll();

            var MonthIncome =  Orders.Where(O => O.CreatedOn.Value.Month == DateTime.Now.Month).Sum(o => o.TotalPrice);
            if (MonthIncome > 0) MonthIncome = 0;

            var LastMonthIncome = Orders.Where(O => O.CreatedOn.Value.Month == DateTime.Now.Month - 1).Sum(o => o.TotalPrice);
            if (LastMonthIncome > 0) LastMonthIncome = 0;

            var IncomeDiff = (MonthIncome - LastMonthIncome);

            var AvgOrder = 0;

            var ReviewsCount = await _unitOfWork.ReviewRepository.GetReviewsCountAsync();

            var vm = new HomeVM()
            {

                ProductsList = ProductsList,
                Orders = Orders,
                MonthIncome = MonthIncome,
                LastMonthIncome = LastMonthIncome,
                IncomeDiff = IncomeDiff,
                AvgOrder = AvgOrder,
                ReviewsCount = ReviewsCount
            };


            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
