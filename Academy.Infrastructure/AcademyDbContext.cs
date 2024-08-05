using Academy.Domain.Entities;
using Academy.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Academy.Infrastructure;

public class AcademyDbContext : DbContext
{
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Mentor> Mentors { get; set; }
    public virtual DbSet<MentorCourse> MentorCourses { get; set; }
    public virtual DbSet<Enrollment> Enrollments { get; set; }
    public virtual DbSet<Group> Groups { get; set; }

    public AcademyDbContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        optionsBuilder.UseSqlServer(DefaultConfiguration.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
