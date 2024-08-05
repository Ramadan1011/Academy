using Academy.Domain.Entities;
using Academy.Domain.Exceptions;
using Academy.Infrastructure;
using AcademyWeb.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AcademyWeb.Stores;

public class MentorCourseStore
{
    public List<MentorCourse> Get(string? search = null)
    {
        using var context = new AcademyDbContext();

        var query = context.MentorCourses
            .AsQueryable()
            .Include(x => x.Mentor)
            .Include(x =>x.Course);

        if (!string.IsNullOrEmpty(search) )
        {
            query = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<MentorCourse, Course>)query.Where(x =>
                x.Mentor.FirstName.Contains(search) ||
                x.Mentor.LastName.Contains(search) || 
                x.Course.Name.Contains(search) ||
                x.Course.Description.Contains(search)); 
        }

        return query.AsNoTracking().ToList();
    }

    public MentorCourse GetById(int id)
    {
        using var context = new AcademyDbContext();

        var mentorCourse = context.MentorCourses
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (mentorCourse is null)
        {
            throw new EntityNotFoundException($"MentorCourse with id: {id} does not exist.");
        }

        return mentorCourse;
    }

    public void Add(MentorCourse mentorCourse)
    {
        using var context = new AcademyDbContext();

        context.MentorCourses.Add(mentorCourse);
        context.SaveChanges();
    }

    public void Update(MentorCourse mentorCourse)
    {
        using var context = new AcademyDbContext();

        var mentorToUpdate = context.MentorCourses.FirstOrDefault(x => x.Id == mentorCourse.Id);

        if (mentorToUpdate == null)
        {
            throw new DataNotFoundException($"MentorCourse with id: {mentorCourse.Id} does not exist.");
        }

        context.Entry(mentorToUpdate).CurrentValues.SetValues(mentorCourse);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        using var context = new AcademyDbContext();
        var mentorCourse = context.MentorCourses.FirstOrDefault(x => x.Id == id);

        if (mentorCourse is null)
        {
            throw new EntityNotFoundException($"MentorCourse with id: {id} does not exist.");
        }

        context.MentorCourses.Remove(mentorCourse);
        context.SaveChanges();
    }
}
