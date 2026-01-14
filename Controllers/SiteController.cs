using CelestialBodies_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CelestialBodies_MVC.Controllers;

public class SiteController : Controller
{
    private readonly DatabaseContext databaseContext = new();

    public async Task<ActionResult> Home()
    {
        return View();
    }

    public async Task<ActionResult<Moon>> All()
    {
        try
        {
            ViewData["Moons"] = await databaseContext.Moons.Include("Planet").OrderBy(m => m.Name).ToListAsync();
            return View();
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public async Task<ActionResult> AddPlanet()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> AddPlanet(string planetName)
    {
        try
        {
            if (planetName == null)
            {
                throw new Exception("Planet can not be null or empty...");
            }
            databaseContext.Planets.Add(new Planet { Name = planetName });
            await databaseContext.SaveChangesAsync();
            return RedirectToAction("All");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public async Task<ActionResult> AddMoon()
    {
        try
        {
            ViewData["Planets"] = await databaseContext.Planets.OrderBy(p => p.Name).ToListAsync();
            return View();
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddMoon(string moonName, int planetId)
    {
        try
        {
            if (moonName == null)
            {
                throw new Exception("Moon can not be null or empty...");
            }
            else if (planetId == 0)
            {
                throw new Exception("Planet can not be null or empty...");
            }
            databaseContext.Moons.Add(new Moon { Name = moonName, PlanetId = planetId });
            await databaseContext.SaveChangesAsync();
            return RedirectToAction("All");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    public async Task<ActionResult> Error()
    {
        ViewData["ErrorMessage"] = TempData["ErrorMessage"];
        return View();
    }
}
