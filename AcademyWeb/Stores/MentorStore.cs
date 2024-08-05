using Academy.Domain.Entities;
using Academy.Domain.Exceptions;
using Academy.Infrastructure;
using AcademyWeb.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AcademyWeb.Stores;

public class MentorStore
{
    public List<Mentor> Get(string? search)
    {
        using var context = new AcademyDbContext();

        var query = context.Mentors.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.FirstName.Contains(search) ||
                x.LastName.Contains(search) ||
                x.PhoneNumber.Contains(search));
        }

        return query.AsNoTracking().ToList();
    }

    public Mentor GetById(int id)
    {
        using var context = new AcademyDbContext();

        var mentor = context.Mentors
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (mentor is null)
        {
            throw new EntityNotFoundException($"Mentor with id: {id} does not exist.");
        }

        return mentor;
    }

    public void Add(Mentor mentor)
    {
        using var context = new AcademyDbContext();

        context.Mentors.Add(mentor);
        context.SaveChanges();
    }

    public void Update(Mentor mentor)
    {
        using var context = new AcademyDbContext();

        var mentorToUpdate = context.Mentors.FirstOrDefault(x => x.Id == mentor.Id);

        if (mentorToUpdate == null)
        {
            throw new DataNotFoundException($"Mentor with id: {mentor.Id} does not exist.");
        }

        context.Entry(mentorToUpdate).CurrentValues.SetValues(mentor);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        using var context = new AcademyDbContext();
        var mentor = context.Mentors.FirstOrDefault(x => x.Id == id);

        if (mentor is null)
        {
            throw new EntityNotFoundException($"Mentor with id: {id} does not exist.");
        }

        context.Mentors.Remove(mentor);
        context.SaveChanges();
    }
}
