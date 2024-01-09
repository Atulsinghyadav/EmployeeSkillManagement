using EmployeeSkillManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSets for your application entities
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId }); // Specify primary key for IdentityUserRole

        // modelBuilder.Entity<Skills>().HasData(
        //     new Skills { Id = 1, SkillName = "Java" },
        //     new Skills { Id = 2, SkillName = "React" },
        //     new Skills { Id = 3, SkillName = "C++" }
        // );

        modelBuilder.Entity<Employee>().ToTable("Employee");
        modelBuilder.Entity<EmployeeSkill>().ToTable("EmployeeSkill");
    }
}
