using Academy.Domain.Enums;

namespace AcademyWeb.ViewModels.Mentor;

public class CreateMentorView
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public Degree Degree { get; set; }
}
