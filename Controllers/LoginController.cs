using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRMSharp.Models;



public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return RedirectToAction("Index", "Dashboard");
    }

    public IActionResult Logout()
    {
        return RedirectToAction("Index");
    }
}
