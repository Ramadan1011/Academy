using Academy.Domain.Enums;
using AcademyWeb.Extensions;
using AcademyWeb.Stores;
using AcademyWeb.ViewModels.Course;
using AcademyWeb.ViewModels.Mentor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyWeb.Controllers;

public class MentorController : Controller
{
    private readonly MentorStore _store;

    public MentorController()
    {
        _store = new();
    }
    // GET: MentorController
    public ActionResult Index(string? search)
    {
        var mentor = _store.Get(search);
        var mentorView = mentor.Select(x => x.ToView());

        return View(mentorView);
    }

    // GET: MentorController/Details/5
    public ActionResult Details(int id)
    {
        var mentor = _store.GetById(id);
        var mentorView = mentor.ToView();

        return View(mentorView);
    }

    // GET: MentorController/Create
    public ActionResult Create()
    {
        var mentor = new MentorViewModel()
        {
            Degrees = (List<SelectListItem>)Enum.GetValues(typeof(Degree))
                           .Cast<Degree>()
                           .Select(d => new SelectListItem
                           {
                               Value = d.ToString(),
                               Text = d.ToString()
                           })
        };
        return View(mentor);
    }

    // POST: MentorController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(MentorViewModel mentor)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var entity = mentor.ToEntity();
            _store.Add(entity);
            return RedirectToAction(nameof(Details), new { id = entity.Id });
        }
        catch
        {
            return View(mentor);
        }
    }

    // GET: MentorController/Edit/5
    public ActionResult Edit(int id)
    {
        var mentor = _store.GetById(id);
        var mentorView = mentor.ToViewModel();

        return View(mentorView);
    }

    // POST: MentorController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, UpdateMentorView mentor)
    {
        try
        {
            var entity = mentor.ToEntityWithId(id);
            _store.Update(entity);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: MentorController/Delete/5
    public ActionResult Delete(int id)
    {
        var mentor = _store.GetById(id);
        var mentorView = mentor.ToView();

        return View(mentorView);
    }

    // POST: MentorController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
