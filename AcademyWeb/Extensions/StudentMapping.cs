using Academy.Domain.Entities;
using AcademyWeb.ViewModels.Student;

namespace AcademyWeb.Extensions;

public static class StudentMapping
{
    public static StudentView ToView(this Student student)
    {
        return new StudentView
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            Phone = student.Phone
        };
    }

    public static UpdateStudentView ToUpdateView(this Student student)
    {
        return new UpdateStudentView
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            Phone = student.Phone
        };
    }

    public static Student ToEntityWithId(this CreateStudentView view, int id)
    {
        return new Student
        {
            Id = id,
            FirstName = view.FirstName,
            LastName = view.LastName,
            Email = view.Email,
            Phone = view.Phone
        };
    }
    public static Student ToEntity(this CreateStudentView view)
    {
        return new Student
        {
            FirstName = view.FirstName,
            LastName = view.LastName,
            Email = view.Email,
            Phone = view.Phone
        };
    }
}
