using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission_08.Models;

namespace Mission_08.Controllers;

public class HomeController : Controller
{
    private ITasksRepository _repo;

    public HomeController(ITasksRepository temp)
    {
        _repo = temp;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Categories = _repo.Category
            .OrderBy(x => x.CategoryName)
            .ToList();
            
        return View();
    }

    [HttpPost]
    public IActionResult Index(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            _repo.AddTask(task);
            return RedirectToAction("Quadrants");
        }
        else
        {
            ViewBag.Categories = _repo.Category
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(task);
        }
    }

    public IActionResult Quadrants()
    {
        // The repository should handle the .Include(x => x.Category) internally 
        // in its "Tasks" property implementation.
        var tasks = _repo.TaskItems.ToList();
        
        return View(tasks);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var taskToEdit = _repo.TaskItems
            .Single(x => x.TaskId == id);

        ViewBag.Categories = _repo.Category
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View("Index", taskToEdit);
    }

    [HttpPost]
    public IActionResult Edit(TaskItem updatedTask)
    {
        if (ModelState.IsValid)
        {
            _repo.UpdateTask(updatedTask);
            return RedirectToAction("Quadrants");
        }
        else
        {
            ViewBag.Categories = _repo.Category
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Index", updatedTask);
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var taskToDelete = _repo.TaskItems
            .Single(x => x.TaskId == id);

        return View(taskToDelete);
    }

    [HttpPost]
    public IActionResult Delete(TaskItem taskToDelete)
    {
        _repo.DeleteTask(taskToDelete);
        
        return RedirectToAction("Quadrants");
    }
}