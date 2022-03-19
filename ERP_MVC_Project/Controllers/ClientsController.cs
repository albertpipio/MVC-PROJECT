using ERP_MVC_Project.Data;
using ERP_MVC_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC_Project.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ERPContext _db;

        public ClientsController(ERPContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Client> objClientList = _db.Clients;
            return View(objClientList);
        }

        //CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        //CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client obj)
        {
            if (obj.Name == obj.Email.ToString())
            {
                ModelState.AddModelError("name", "The name cannot exactly match the Email.");
            }
            if (ModelState.IsValid)
            {
                _db.Clients.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Client created successfully";
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
            var ClientFromDb = _db.Clients.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (ClientFromDb == null)
            {
                return NotFound();
            }

            return View(ClientFromDb);
        }

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client obj)
        {
            if (obj.Name == obj.Email.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot exactly match the Email.");
            }
            if (ModelState.IsValid)
            {
                _db.Clients.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Client updated successfully";
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
            var ClientFromDb = _db.Clients.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (ClientFromDb == null)
            {
                return NotFound();
            }

            return View(ClientFromDb);
        }

        //DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Guid? id)
        {
            var obj = _db.Clients.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Clients.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Client deleted successfully";
            return RedirectToAction("Index");
        }
    }

}
