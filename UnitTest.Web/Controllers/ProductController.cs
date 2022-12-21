using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTest.Web.Models;
using UnitTest.Web.Repository;

namespace UnitTest.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public readonly IRepository<Products> _repository;

        public ProductController(IRepository<Products> repository)
        {
            _repository = repository;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _repository.GetAll());
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            var product =await _repository.GetById((int)id);
            if (product==null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products product)
        {
            try
            {
                if (ModelState.IsValid) { _repository.Create(product); return RedirectToAction(nameof(Index)); }
              
                return View(product);
               
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product=_repository.GetById(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Products product)
        {
            try
            {
                var oldProduct = _repository .GetById(id);
                if (oldProduct==null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _repository.Update(product);
                    return RedirectToAction(nameof(Index));
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = _repository.GetById(id);
             return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Products product)
        {
            try
            {
              _repository.Delete(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
