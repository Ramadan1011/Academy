using Academy.Domain.Enums;

namespace Academy.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public StudyMode Mode { get; set; }
    public CourseType Type { get; set; }

    public int MentorCourseId { get; set; }
    public virtual MentorCourse MentorCourse { get; set; }

    public virtual IEnumerable<Enrollment> Enrollments { get; set; }
}
