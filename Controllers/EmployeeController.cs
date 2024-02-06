using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSkillManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeSkillManagement.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Employee> objEmployeeList = _db.Employees.ToList();
            return View(objEmployeeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if(ModelState.IsValid)
            {
            _db.Employees.Add(obj);
            _db.SaveChanges();
            TempData["Success"] = "Employee Created Successfully";
            return RedirectToAction("Index");
            }
            return View();
        }
        

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }

        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id==0){
                return NotFound();
            }
            Employee? employeeFromDb = _db.Employees.Find(Id);
            if(employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if(ModelState.IsValid)
            {
            _db.Employees.Update(obj);
            _db.SaveChanges();
            TempData["Success"] = "Employee Updated Successfully";
            return RedirectToAction("Index");
            }
            return View();
        }
        

         public IActionResult Delete(int? Id)
        {
            if(Id==null || Id==0){
                return NotFound();
            }
            Employee? employeeFromDb = _db.Employees.Find(Id);
            if(employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            Employee? obj = _db.Employees.Find(Id);
            if (obj == null){
                return NotFound();
            }

            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Employee Deleted Successfully";
            return RedirectToAction("Index");
           
        }
    }
}