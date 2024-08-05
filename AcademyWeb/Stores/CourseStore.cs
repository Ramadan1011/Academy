using Academy.Domain.Entities;
using Academy.Domain.Exceptions;
using Academy.Infrastructure;
using AcademyWeb.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AcademyWeb.Stores;

public class CourseStore
{
    public List<Course> Get(string? search)
    {
        using var context = new AcademyDbContext();

        var query = context.Courses.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Name.Contains(search) ||
                (x.Description != null && x.Description.Contains(search)));
        }

        return query.AsNoTracking().ToList();
    }

    public Course GetById(int id)
    {
        using var context = new AcademyDbContext();

        var course = context.Courses
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (course is null)
        {
            throw new EntityNotFoundException($"Course with id: {id} does not exist.");
        }

        return course;
    }

    public void Add(Course course)
    {
        ValidateCourse(course);

        using var context = new AcademyDbContext();

        context.Courses.Add(course);
        context.SaveChanges();
    }

    public void Update(Course course)
    {
        ValidateCourse(course);

        using var context = new AcademyDbContext();

        var courseToUpdate = context.Courses.FirstOrDefault(x => x.Id == course.Id);
        
        if (courseToUpdate == null)
        {
            throw new DataNotFoundException($"Course with id: {course.Id} does not exist.");
        }

        context.Entry(courseToUpdate).CurrentValues.SetValues(course);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        using var context = new AcademyDbContext();
        var course = context.Courses.FirstOrDefault(x => x.Id == id);

        if (course is null)
        {
            throw new EntityNotFoundException($"Course with id: {id} does not exist.");
        }

        context.Courses.Remove(course);
        context.SaveChanges();
    }

    private static void ValidateCourse(Course Course)
    {
        ArgumentNullException.ThrowIfNull(Course);

        if (Course.Price < 1)
        {
            throw new InvalidPriceException("Price must be greater than 0");
        }
    }
}
