﻿namespace Academy.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string Phone { get; set; }

    public virtual IEnumerable<Enrollment> Enrollments { get; set; }
}
