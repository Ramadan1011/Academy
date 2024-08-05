using AcademyWeb.Extensions;
using AcademyWeb.Stores;
using AcademyWeb.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;

namespace AcademyWeb.Controllers;

public class CourseController : Controller
{
    private readonly CourseStore _courseStore;

    public CourseController()
    {
        _courseStore = new();
    }

    public ActionResult Index(string? search)
    {
        var course = _courseStore.Get(search);
        var courseViews = course.Select(x => x.ToView());

        ViewBag.Search = search;

        return View(courseViews);
    }

    public ActionResult Details(int id)
    {
        var course = _courseStore.GetById(id);
        var courseView = course.ToView();

        return View(courseView);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateCourseView course)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var entity = course.ToEntity();
            _courseStore.Add(entity);
            return RedirectToAction(nameof(Details), new { id = entity.Id });
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Edit(int id)
    {
        var course = _courseStore.GetById(id);
        var courseView = course.ToUpdateView();

        return View(courseView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, UpdateCourseView view)
    {
        try
        {
            var entity = view.ToEntityWithId(id);
            _courseStore.Update(entity);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Delete(int id)
    {
        var course = _courseStore.GetById(id);
        var courseView = course.ToView();

        return View(courseView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            _courseStore.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
