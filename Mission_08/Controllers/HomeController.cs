using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission_08.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        ViewBag.Categories = new SelectList(_repo.Categories
            .OrderBy(x => x.Name));
            
        return View(new TaskItem());
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
            ViewBag.Categories = new SelectList(_repo.Categories
                .OrderBy(x => x.Name));
            return View(task);
        }
    }

    public IActionResult Quadrants()
    {
        var tasks = _repo.TaskItems.ToList();
        
        return View(tasks);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var taskToEdit = _repo.TaskItems
            .Single(x => x.TaskId == id);

        ViewBag.Categories = new SelectList(_repo.Categories
            .OrderBy(x => x.Name));

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
            ViewBag.Categories =new SelectList(_repo.Categories
                .OrderBy(x => x.Name));
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