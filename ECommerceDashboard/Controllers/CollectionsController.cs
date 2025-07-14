using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceDashboard.BLL.Repositoy;
using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Entities.Products;

namespace ECommerceDashboard.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: Collections
        public async Task<IActionResult> Index()
        {
            var collections = await _unitOfWork.CollectionRepository.GetAll();
            return View(collections);
        }

        // GET: Collections/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = _unitOfWork.CollectionRepository.GetById(id);

            if (collection == null)
            {
                return NotFound();
            }

            return View(collection);
        }

        // GET: Collections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description")] Collection collection)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CollectionRepository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            return View(collection);
        }

        // GET: Collections/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = _unitOfWork.CollectionRepository.GetById(id);
            if (collection == null)
            {
                return NotFound();
            }
            return View(collection);
        }

        // POST: Collections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,CreatedOn,IsDeleted")] Collection collection)
        {
            if (id != collection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CollectionRepository.Update(collection);
                }
                catch (DbUpdateConcurrencyException)
                {

                        return NotFound();       
                }
                return RedirectToAction(nameof(Index));
            }
            return View(collection);
        }

        // GET: Collections/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection =  _unitOfWork.CollectionRepository.GetById(id);
            if (collection == null)
            {
                return NotFound();
            }

            return View(collection);
        }

        // POST: Collections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var collection = _unitOfWork.CollectionRepository.GetById(id);
            if (collection != null)
            {
                _unitOfWork.CollectionRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
