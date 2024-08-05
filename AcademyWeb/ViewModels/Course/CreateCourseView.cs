using System.ComponentModel;

namespace AcademyWeb.ViewModels.Course;

public class CreateCourseView
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    [DisplayName("Number of Modules")]
    public int NumberOfModules { get; set; }
    public double Rating { get; set; }
    public decimal Discount { get; set; }
}
