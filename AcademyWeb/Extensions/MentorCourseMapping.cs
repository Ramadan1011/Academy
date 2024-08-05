using Academy.Domain.Entities;
using Academy.Infrastructure;
using AcademyWeb.Stores;
using AcademyWeb.ViewModels.MentorCourse;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcademyWeb.Extensions;

public static class MentorCourseMapping
{
    public static MentorCourseViewModel ToViewModel(this List<MentorCourse> mentorCourses)
    {
        //using (var context = new AcademyDbContext())
        //{
        //    var courses = context.Courses.Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString(),
        //        Text = x.Name
        //    }).ToList();

        //    if (courses == null)
        //    {
        //        throw new Exception();
        //    }
        //}

        return new MentorCourseViewModel()
        {
            //FullName = $"{mentorCourse.Mentor.FirstName} {mentorCourse.Mentor.LastName}",
            //Name = mentorCourse.Course.Name,
            Courses = mentorCourses.Select(mc => new SelectListItem
            {
                Value = 
            })
        };
    }
    public static MentorCourseView ToView(this MentorCourse mentorCourse)
    {
        return new MentorCourseView
        {
            Id = mentorCourse.Id,
            CourseId = mentorCourse.CourseId,
            FullName = mentorCourse.Mentor.FirstName + mentorCourse.Mentor.LastName,
            MentorId = mentorCourse.Id,
            Name = mentorCourse.Course.Name
        };
    }

    public static UpdateMentorCourseView ToUpdateView(this MentorCourse mentorCourse)
    {
        return new UpdateMentorCourseView
        {
            CourseId = mentorCourse.CourseId,
            FullName = mentorCourse.Mentor.FirstName + mentorCourse.Mentor.LastName,
            MentorId = mentorCourse.Id,
            Name = mentorCourse.Course.Name
        };
    }

    public static MentorCourse ToEntityById(this CreateMentorCourseView view, int id)
    {
        return new MentorCourse
        {
            Id = id,
            CourseId = view.CourseId,
            MentorId = view.MentorId
        };
    }
    public static MentorCourse ToEntity(this CreateMentorCourseView view)
    {
        return new MentorCourse
        {
            CourseId = view.CourseId,
            MentorId = view.MentorId
        };
    }
}
