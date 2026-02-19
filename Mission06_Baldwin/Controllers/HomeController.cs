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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        return View("MovieForm", new Movie());
    }
    
    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); // add record to the database and save
            _context.SaveChanges();

            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieForm", new Movie());
        }
    }
    
    public IActionResult ViewMovieCollection()
    {
        // Linq query - a pseudo SQL language
        var movies = _context.Movies
            .OrderBy(x => x.Title).ToList();
        
        return View(movies);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("MovieForm", recordToEdit);
    }
    
    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovieCollection");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);

        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("ViewMovieCollection");
    }
}