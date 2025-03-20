using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Param.Models;

namespace Param.Controllers;

public class HomeController : Controller
{
     private static List<TaskModel> tasks = new();

     public IActionResult Index()
     {
        return View(tasks);
     }

     [HttpPost]
     public IActionResult AddTask(string description)
     {
         if (!string.IsNullOrWhiteSpace(description))
        {
             tasks.Add(new TaskModel {Id =tasks.Count + 1,Description= description});
        }
        return RedirectToAction("Index");
     }



     [HttpPost]
     public IActionResult DeleteTask(int id){
        tasks.RemoveAll(t => t.Id==id);
        return RedirectToAction("Index");
     }

   
}
