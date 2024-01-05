using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSkillManagement.Models
{
   public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public  string? Firstname { get; set; }
    
    [Required]
    [Display(Name = "Last Name")]
    public string? Lastname { get; set; }

    [Required]
    public string Designation {get; set; }
   
    
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "DOJ")]
    public DateTime DOJ { get; set; }

    public List<Skills>? skill {get; set;}
}

}