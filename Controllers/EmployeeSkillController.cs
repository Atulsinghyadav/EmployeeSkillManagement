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
    [Authorize(Roles = "Admin")]

    public class EmployeeSkillController : Controller
    {
        
        static int empId;

        private readonly ApplicationDbContext _db;

        public EmployeeSkillController(ApplicationDbContext db)
        {
            _db = db;
        }

        // public IActionResult Index(){
        //     return View();
        // }
        public IActionResult Index(int id)
        {
            var esData = _db.EmployeeSkills.ToList();
            var sData = _db.Skills.ToList();

            List<ViewSkill> vs = new List<ViewSkill>();

            foreach(EmployeeSkill item in esData)
            {
                if(item.EmployeeId == id)
                {
                ViewSkill temp = new ViewSkill();
                temp.empSkillId = item.Id;
                temp.experience = item.Experience;
                temp.level = item.Expert_Level;
                var t = sData.FirstOrDefault(s => s.Id == item.SkillId);
                temp.name = t.SkillName;
                vs.Add(temp);
                }
            }
        
            return View(vs);
        }
        
        [HttpGet("/EmployeeSkill/create/{Id}")]
        public IActionResult Create(int Id)
        {
            empId = Id;
            return View(_db.Skills.ToList());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int Id, int experience, int Rating)
        {
            EmployeeSkill es = new EmployeeSkill();
            es.EmployeeId = empId;
            es.SkillId = Id;
            es.Experience = experience;
            es.Expert_Level = Rating;

            _db.EmployeeSkills.Add(es);
            _db.SaveChanges();
            TempData["Success"] = "Skill Added Successfully";
            return RedirectToAction("Index", "Employee");
        }
        
        public IActionResult Delete(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            } 

            var empSkillFromDb = _db.EmployeeSkills.Find(id);

            if(empSkillFromDb == null)
            {
                return NotFound();
            }

            _db.EmployeeSkills.Remove(empSkillFromDb);
            _db.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.EmployeeSkills.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.EmployeeSkills.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Skill Deleted Successfully";
            return RedirectToAction("Index", "Employee");
        }
    }
}