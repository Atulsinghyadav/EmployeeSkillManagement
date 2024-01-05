using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace EmployeeSkillManagement.Models
{
    public class EmployeeSkill
    {

        [Key]
        public int Id {get; set;}

        [ForeignKey("Skills")]
        public int? SkillId {get; set;}

        [ForeignKey("Employee")]
        public int EmployeeId {get; set; }

        // public Employee employee {get; set;}

        [Required]
        [Display(Name = "Expert Level")]
        public int Expert_Level {get; set;}

        [Required]
        public int Experience {get; set; }
    }
}