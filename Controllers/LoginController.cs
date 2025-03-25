using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRMSharp.ViewModels;
using CRMSharp.Models;

public class LoginController : Controller
{
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService){
        _loginService = loginService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost] // Cette action reçoit les données du formulaire
    public async Task<IActionResult> LoginAsync(LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            // Si la validation échoue, on réaffiche le formulaire
            return View("Index", model);
        }

        // Ici vous pouvez traiter la connexion
        var email = model.Input.Email;
        
        // Exemple basique de logique de connexion
        if (await IsValidUserAsync(email)) // À remplacer par votre propre logique
        {
            // Stocker l'email en session
            HttpContext.Session.SetString("UserEmail", model.Input.Email);
            
            // // Optionnel : Stocker d'autres données
            // HttpContext.Session.SetInt32("UserId", GetUserIdByEmail(model.Input.Email));
            
            // Ajouter un message temporaire
            TempData["LoginSuccess"] = "Connexion réussie";

            return RedirectToAction("Index", "Dashboard");
        }
        
        // Authentification échouée
        ModelState.AddModelError(string.Empty, "Login failed");
        return View("Index", model);
    }

    private async Task<bool> IsValidUserAsync(string email)
    {
        bool result = await _loginService.CheckLogin(email);
        return result;
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
