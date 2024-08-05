﻿using Academy.Domain.Entities;
using AcademyWeb.Extensions;
using AcademyWeb.Stores;
using AcademyWeb.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;

namespace AcademyWeb.Controllers;

public class StudentController : Controller
{
    private readonly StudentStore _store;
    public StudentController()
    {
        _store = new();
    }
    public ActionResult Index(string? search)
    {
        var students = _store.Get(search);
        var studentsView = students.Select(x => x.ToView());

        ViewBag.Search = search;

        return View(studentsView);
    }

    public ActionResult Details(int id)
    {
        var student = _store.GetById(id);
        var studentView = student.ToView();

        return View(studentView);
    }

    public ActionResult Create()
    {
        return View();
    }

    // POST: StudentController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateStudentView student)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var entity = student.ToEntity();
            _store.Add(entity)  ;
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Edit(int id)
    {
        var student = _store.GetById(id);
        var studentView = student.ToUpdateView();

        return View(studentView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, UpdateStudentView student)
    {
        try
        {
            var entity = student.ToEntityWithId(id);
            _store.Update(entity);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Delete(int id)
    {
        var student = _store.GetById(id);
        var studentView = student.ToView();

        return View(studentView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            _store.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
