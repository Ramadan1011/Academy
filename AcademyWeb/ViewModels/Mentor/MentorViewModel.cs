using Academy.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyWeb.ViewModels.Mentor;

public class MentorViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public Degree Degree { get; set; }
    public List<SelectListItem> Degrees { get; set; }
}
