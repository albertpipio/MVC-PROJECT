using ERP_MVC_Project.Data;
using ERP_MVC_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC_Project.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ERPContext _db;

        public ItemsController(ERPContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objItemList = _db.Items;
            return View(objItemList);
        }

        //CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        //CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (obj.Description == obj.Category.ToString())
            {
                ModelState.AddModelError("description", "The Description cannot exactly match the Category.");
            }
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Item created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //EDIT GET
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ItemFromDb = _db.Items.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (ItemFromDb == null)
            {
                return NotFound();
            }

            return View(ItemFromDb);
        }

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item obj)
        {
            if (obj.Description == obj.Category.ToString())
            {
                ModelState.AddModelError("description", "The Description cannot exactly match the Category.");
            }
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Item updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //DELETE GET
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ItemFromDb = _db.Items.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (ItemFromDb == null)
            {
                return NotFound();
            }

            return View(ItemFromDb);
        }

        //DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Guid? id)
        {
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Items.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Item deleted successfully";
            return RedirectToAction("Index");
        }
    }

}
