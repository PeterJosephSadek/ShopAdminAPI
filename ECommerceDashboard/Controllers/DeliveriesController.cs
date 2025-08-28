using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Entities.Orders;
using ECommerceDashboard.DAL.Interfaces;


namespace ECommerceDashboard.Controllers
{
    public class DeliveriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeliveriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Deliveries
        public IActionResult Index()
        {
            return View(_unitOfWork.DeliveryRepository.GetAll());
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _unitOfWork.DeliveryRepository.GetById(id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Region,DeliveryFees,IsDefault")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.DeliveryRepository.Add(delivery);
                return RedirectToAction(nameof(Index));
            }
            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _unitOfWork.DeliveryRepository.GetById(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Region,DeliveryFees,IsDefault")] Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.DeliveryRepository.Update(delivery);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.DeliveryRepository.GetById(delivery.Id) == null)
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
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _unitOfWork.DeliveryRepository.GetById(id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var delivery = _unitOfWork.DeliveryRepository.GetAll();
            if (delivery != null)
            {
                 _unitOfWork.DeliveryRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
