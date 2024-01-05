  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;
  using System.Linq;
  using System.Threading.Tasks;

  namespace EmployeeSkillManagement.Models
  {
      public class ViewSkill
      {
          
        [Key]
        public int empSkillId {get; set;}

        public string name {get; set ;}

        public int level {get; set; }

        public int experience {get; set; }

      }
  }