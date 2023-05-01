using FreeCC_MVC_web.Data;
using FreeCC_MVC_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeCC_MVC_web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }


        public IActionResult create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult create(category obj)
        {
            if (obj.Name == obj.DisplayOdrder.ToString()){
                ModelState.AddModelError("name", "Name and Display Order cannot be the same.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(Id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(category obj)
        {
            if (obj.Name == obj.DisplayOdrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Order cannot be the same.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(Id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(category obj)
        {
            if (obj.Name == obj.DisplayOdrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Order cannot be the same.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
