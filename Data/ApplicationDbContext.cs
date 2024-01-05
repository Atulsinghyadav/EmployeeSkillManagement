using EmployeeSkillManagement.Controllers;
using EmployeeSkillManagement.Models;
using EmployeeSkillsManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                 
        }
        public DbSet<Employee> Employees { get; set; }

         public DbSet<Skills> Skills {get; set;}

        public DbSet<EmployeeSkill> EmployeeSkills {get; set;}
    

    public DbSet<Admin> Admins{ get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Skills>().HasData(
            new Skills { Id = 1, SkillName = "Java"},
            new Skills { Id = 2, SkillName = "React"},
            new Skills { Id = 3, SkillName = "C++"}
        );
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<EmployeeSkill>().ToTable("EmployeeSkill");

            

    
    }

    
}
