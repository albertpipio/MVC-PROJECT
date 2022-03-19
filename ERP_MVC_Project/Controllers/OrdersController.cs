using ERP_MVC_Project.Data;
using ERP_MVC_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC_Project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ERPContext _db;

        public OrdersController(ERPContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> objOrderList = _db.Orders;
            return View(objOrderList);
        }

        //CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        //CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order obj)
        {
            if (obj.Status == obj.Priority.ToString())
            {
                ModelState.AddModelError("status", "The Status cannot exactly match the Priority.");
            }
            if (ModelState.IsValid)
            {
                _db.Orders.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Order created successfully";
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
            var OrderFromDb = _db.Orders.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (OrderFromDb == null)
            {
                return NotFound();
            }

            return View(OrderFromDb);
        }

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order obj)
        {
            if (obj.Status == obj.Priority.ToString())
            {
                ModelState.AddModelError("status", "The Status cannot exactly match the Priority.");
            }
            if (ModelState.IsValid)
            {
                _db.Orders.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Order updated successfully";
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
            var OrderFromDb = _db.Orders.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (OrderFromDb == null)
            {
                return NotFound();
            }

            return View(OrderFromDb);
        }

        //DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Guid? id)
        {
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Orders.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Order deleted successfully";
            return RedirectToAction("Index");
        }
    }

}
