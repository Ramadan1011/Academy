using Academy.Domain.Entities;
using Academy.Domain.Enums;
using AcademyWeb.ViewModels.Mentor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyWeb.Extensions;

public static class MentorMapping
{
    public static MentorViewModel ToViewModel(this Mentor mentor)
    {
        return new MentorViewModel()
        {
            FirstName = mentor.FirstName,
            LastName = mentor.LastName,
            PhoneNumber = mentor.PhoneNumber,
            Degree = mentor.Degree,
            Degrees = Enum.GetValues(typeof(Degree))
                       .Cast<Degree>()
                       .Select(d => new SelectListItem
                       {
                           Value = d.ToString(),
                           Text = d.ToString(),
                           Selected = d == mentor.Degree
                       }).ToList()
        };
    }
    public static MentorView ToView(this Mentor mentor)
    {
        return new MentorView
        {
            Id = mentor.Id,
            FirstName = mentor.FirstName,
            LastName = mentor.LastName,
            PhoneNumber = mentor.PhoneNumber,
            Degree = mentor.Degree,
        };
    }

    public static UpdateMentorView ToUpdateView(this Mentor mentor)
    {
        return new UpdateMentorView
        {
            FirstName = mentor.FirstName,
            LastName = mentor.LastName,
            PhoneNumber = mentor.PhoneNumber,
            Degree = mentor.Degree,
        };
    }

    public static Mentor ToEntityWithId(this CreateMentorView view, int id)
    {
        return new Mentor
        {
            Id = id,
            FirstName = view.FirstName,
            LastName = view.LastName,
            PhoneNumber = view.PhoneNumber,
            Degree = view.Degree,
        };
    }
    public static Mentor ToEntity(this MentorViewModel view)
    {
        return new Mentor
        {
            FirstName = view.FirstName,
            LastName = view.LastName,
            PhoneNumber = view.PhoneNumber,
            Degree = view.Degree,
        };
    }
}
