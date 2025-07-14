using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceDashboard.BLL.Interfaces;
using ECommerceDashboard.DAL.Entities.Products;

namespace ECommerceDashboard.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Products
        public IActionResult Index(string searchQuery)
        {
            // Store the search query in ViewBag to repopulate the search bar
            ViewBag.SearchQuery = searchQuery;

            // Query the database
            var query = _unitOfWork.ProductRepository.GetAll();

            // Apply the search filter if a search query is provided
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList(); // Search by product name
            }

            // Execute the query and pass the results to the view
            return View(query);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _unitOfWork.ProductRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            
            ViewData["CollectionId"] =  new SelectList(await _unitOfWork.CollectionRepository.GetAll(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Description,CollectionId,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                 _unitOfWork.ProductRepository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollectionId"] = new SelectList(await _unitOfWork.CollectionRepository.GetAll(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _unitOfWork.ProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.CategoryRepository.GetAll(), "Id", "Name", product.CategoryId);
            ViewData["CollectionId"] = new SelectList(await _unitOfWork.CollectionRepository.GetAll(), "Id", "Name", product.CollectionId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,CreatedOn,IsDeleted,CollectionId,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ProductRepository.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                     //
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.CategoryRepository.GetAll(), "Id", "Name", product.CategoryId);
            ViewData["CollectionId"] = new SelectList(await _unitOfWork.CollectionRepository.GetAll(), "Id", "Name", product.CollectionId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _unitOfWork.ProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Product product = _unitOfWork.ProductRepository.GetById(id);
            if (product != null)
            {
                _unitOfWork.ProductRepository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
