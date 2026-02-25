using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using Mission_08.Models;

namespace Mission_08.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
}