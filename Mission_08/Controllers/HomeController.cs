using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//using Mission_08.Models;

namespace Mission_08.Controllers;

public class HomeController : Controller
{
    private ITasksItemsRepository _context;

    public HomeController(ITasksItemsRepository temp)
    {
        _context = temp;
    }
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.TaskItems = _context
            .OrderBy(t => t.Quadrant)
            .toList();
        return View();
    }
    [HttpPost]
        public IActionResult Index(Task task)
        {
            if (ModelState.IsValid)
            {
                _context.TaskItems.Add(task);
                _context.SaveChanges();
                return View("Quadrants", task);
            }
            else
            {
                ViewBag.Categories = _context.TaskItems
                    .OrderBy(t => t.Quadrant)
                    .ToList();
                return View();
            }
        }
    public IActionResult Quadrants()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var TaskToEdit = _context.TaskItems
            .Single(x=>x.TaskId==id);
        ViewBag.TaskItems = _context
            .OrderBy(t => t.Quadrant)
            .toList();
        return View("Index", TaskToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Task UpdatedTask)
    {
        if (ModelState.IsValid)
        {
            _context.TaskItems.Update(UpdatedTask);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.TaskItems = _context
                .OrderBy(t => t.Quadrant)
                .toList();
            return View("Index", UpdatedTask);
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var TaskToDelete = _context.TaskItems
            .Single(x=>x.TaskId==id);
        return View("Quadrants");
    }

    [HttpPost]
    public IActionResult Delete(Task TaskToDelete)
    {
        _context.TaskItems.Remove(TaskToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    
    
}