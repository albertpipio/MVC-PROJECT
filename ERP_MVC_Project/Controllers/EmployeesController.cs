using ERP_MVC_Project.Data;
using ERP_MVC_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ERPContext _db;

        public EmployeesController(ERPContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> objEmployeeList = _db.Employees;
            return View(objEmployeeList);
        }

        //CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        //CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (obj.Name == obj.Surname.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot exactly match the Surname.");
            }
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee created successfully";
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
            var EmployeeFromDb = _db.Employees.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }

            return View(EmployeeFromDb);
        }

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (obj.Name == obj.Surname.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot exactly match the Surname.");
            }
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee updated successfully";
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
            var EmployeeFromDb = _db.Employees.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }

            return View(EmployeeFromDb);
        }

        //DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Guid? id)
        {
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");
        }
    }

}
