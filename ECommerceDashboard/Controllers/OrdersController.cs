using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Entities.Orders;
using ECommerceDashboard.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ECommerceDashboard.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ECommerceDbContext _context;

        public OrdersController(IUnitOfWork unitOfWork, ECommerceDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.OrderRepository.GetAll());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _unitOfWork.OrderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CreateOrder = new CreateOrderViewModel();
            CreateOrder.AvailableProducts = _unitOfWork.ProductRepository.GetAll();


            return View(CreateOrder);
        }

        // POST: Orders/Create
        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel CreateOrder)
        {


            return View(CreateOrder);
        }

        // AJAX endpoint to get product price
        [HttpGet]
        public async Task<JsonResult> GetProductPrice(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                return Json(new { success = true, price = product.Price });
            }
            return Json(new { success = false });
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _unitOfWork.OrderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,PhoneNumber,Address,AddressLocation,TotalPrice,Comment,CreatedOn,IsDeleted")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.OrderRepository.Update(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.OrderRepository.GetById(order.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _unitOfWork.OrderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.OrderRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
