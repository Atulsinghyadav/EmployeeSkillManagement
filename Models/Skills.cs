using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSkillManagement.Models
{
    public class Skills
    {
        
        [Key]
        public int Id {get; set;}

        [Display(Name = "Skill Name")]
        [Required]
        public string SkillName {get; set;}
    }
}