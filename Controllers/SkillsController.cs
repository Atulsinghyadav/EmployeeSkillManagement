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
    // [Route("[controller]")]

    // [Authorize(Policy = "RequireAdminRole")]
    public class SkillsController : Controller
    {

        private readonly ApplicationDbContext _db;
        
        public SkillsController(ApplicationDbContext db)
        {
                _db = db;
        }

        public IActionResult Index()
        {
            List<Skills> objSkillList = _db.Skills.ToList();
            return View(objSkillList);
        }

        // [HttpGet("Create")]
        public IActionResult Create(){
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Skills obj)
        {
            if (ModelState.IsValid)
            {
                var data = _db.Skills.ToList();
                var check = data.Where(s => s.SkillName.ToLower().Contains(obj.SkillName.ToLower())).FirstOrDefault();
                if (check == null)
                {
                    _db.Skills.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Skills created successfully";
                    return RedirectToAction("Index");
                }
                else
                {

                    TempData["warning"] = "Skill already exists";
                }
            }
            return View(obj);
        }


        
        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id==0){
                return NotFound();
            }
            Skills? skillsFromDb = _db.Skills.Find(Id);
            if(skillsFromDb == null)
            {
                return NotFound();
            }
            return View(skillsFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Skills obj)
        {
            if(ModelState.IsValid)
            {
            _db.Skills.Update(obj);
            _db.SaveChanges();
            TempData["Success"] = "Skill Updated Successfully";
            return RedirectToAction("Index");
            }
            return View();
        }
        

          public IActionResult Delete(int? Id)
        {
            if(Id==null || Id==0){
                return NotFound();
            }
            Skills? skillsFromDb = _db.Skills.Find(Id);
            if(skillsFromDb == null)
            {
                return NotFound();
            }
            return View(skillsFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            Skills? obj = _db.Skills.Find(Id);
            if (obj == null){
                return NotFound();
            }

            // var es = _db.EmployeeSkills.FirstOrDefault(es => es.SkillId == Id);

            // if (es != null)

            // {
            //     TempData["warning"] = "Skill is assigned to employee";

            //     return Redirect(Request.Headers["Referer"].ToString());
            // }
            _db.Skills.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Skill Deleted Successfully";
            return RedirectToAction("Index");
            // if(ModelState.IsValid)
            // {
            // _db.Employees.Update(obj);
            // _db.SaveChanges();
            // return RedirectToAction("Index");
            // }
            // return View();
        }

        
    }
}