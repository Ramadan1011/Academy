using Academy.Domain.Entities;
using Academy.Domain.Exceptions;
using Academy.Infrastructure;
using AcademyWeb.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AcademyWeb.Stores;

public class StudentStore
{
    public List<Student> Get(string? search)
    {
        using var context = new AcademyDbContext();

        var query = context.Students.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => 
                x.FirstName.Contains(search) || 
                x.LastName.Contains(search) ||
                (x.Email != null && x.Email.Contains(search)) ||
                x.Phone.Contains(search));
        }

        return query.AsNoTracking().ToList();
    }

    public Student GetById(int id)
    {
        using var context = new AcademyDbContext();

        var course = context.Students
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (course is null)
        {
            throw new EntityNotFoundException($"Student with id: {id} does not exist.");
        }

        return course;
    }

    public void Add(Student student)
    {
        using var context = new AcademyDbContext();

        context.Students.Add(student);
        context.SaveChanges();
    }

    public void Update(Student student)
    {
        using var context = new AcademyDbContext();

        var studentToUpdate = context.Students.FirstOrDefault(x => x.Id == student.Id);

        if (studentToUpdate == null)
        {
            throw new DataNotFoundException($"Student with id: {student.Id} does not exist.");
        }

        context.Entry(studentToUpdate).CurrentValues.SetValues(student);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        using var context = new AcademyDbContext();
        var student = context.Students.FirstOrDefault(x => x.Id == id);

        if (student is null)
        {
            throw new EntityNotFoundException($"Student with id: {id} does not exist.");
        }

        context.Students.Remove(student);
        context.SaveChanges();
    }
}
