using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyWeb.ViewModels.MentorCourse;

public class MentorCourseViewModel
{
    public int Id { get; set; }
    public int MentorId { get; set; }
    public string FullName { get; set; }
    public int CourseId { get; set; }
    public string Name { get; set; }

    public List<SelectListItem> Courses { get; set; }
    public List<SelectListItem> Mentors { get; set; }
}
