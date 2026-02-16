// This application is a website intended to be an intro to Joel Hilton. It allows users to add movies
// to a database of movies they own.
// Made by Ryan Baldwin, section 002

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6Assignment.Models;

namespace Mission6Assignment.Controllers;

public class HomeController : Controller
{
    private MovieFormContext _context;
    
    public HomeController(MovieFormContext temp) // Constructor
    {
        _context = temp;
    }
    
    // simply calls each of the views
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        _context.Movies.Add(response); // add record to the database and save
        _context.SaveChanges();
        
        return View("Confirmation", response);    
    }
}