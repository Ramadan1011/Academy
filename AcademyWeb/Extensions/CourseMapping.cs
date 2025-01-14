﻿using Academy.Domain.Entities;
using AcademyWeb.ViewModels.Course;

namespace AcademyWeb.Extensions;

public static class CourseMapping
{
    public static CourseView ToView(this Course course)
    {
        return new CourseView
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description,
            Discount = course.Discount,
            NumberOfModules = course.NumberOfModules,
            Price = course.Price,
            Rating = course.Rating,
        };
    }

    public static UpdateCourseView ToUpdateView(this Course course)
    {
        return new UpdateCourseView
        {
            Name = course.Name,
            Description = course.Description,
            Discount = course.Discount,
            NumberOfModules = course.NumberOfModules,
            Price = course.Price,
            Rating = course.Rating,
        };
    }

    public static Course ToEntityWithId(this CreateCourseView view, int id)
    {
        return new Course
        {
            Id = id,
            Name = view.Name,
            Description = view.Description,
            Discount = view.Discount,
            NumberOfModules = view.NumberOfModules,
            Price = view.Price,
            Rating = view.Rating,
        };
    }
    public static Course ToEntity(this CreateCourseView view)
    {
        return new Course
        {
            Name = view.Name,
            Description = view.Description,
            Discount = view.Discount,
            NumberOfModules = view.NumberOfModules,
            Price = view.Price,
            Rating = view.Rating,
        };
    }
}
