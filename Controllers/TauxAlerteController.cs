using Microsoft.AspNetCore.Mvc;
using CRMSharp.Models;

public class TauxAlerteController : Controller
{
    private readonly TauxAlerteService _tauxAlerteService;

    public TauxAlerteController(TauxAlerteService tauxAlerteService)
    {
        _tauxAlerteService = tauxAlerteService;
    }

    // Afficher le formulaire de création
    public IActionResult Create()
    {
        var userEmail = HttpContext.Session.GetString("UserEmail");
        
        if (string.IsNullOrEmpty(userEmail))
        {
            return RedirectToAction("Index", "Login");
        }else{
            return View();
        }
    }

    // Traiter la soumission du formulaire
    [HttpPost]
    public async Task<IActionResult> CreateTaux(TauxAlerte tauxAlerte)
    {
        // Récupérer l'email depuis la session
        var userEmail = HttpContext.Session.GetString("UserEmail");
        
        if (string.IsNullOrEmpty(userEmail))
        {
            return RedirectToAction("Index", "Login");
        }

        else{
            if (ModelState.IsValid)
            {
                bool result = await _tauxAlerteService.CreateTauxAlerteAsync(tauxAlerte);
                if (result)
                {
                    TempData["SuccessMessage"] = "Taux d'alerte créé avec succès !";
                    return RedirectToAction("Index", "Dashboard"); // Rediriger vers la page d'accueil
                }
                else
                {
                    ModelState.AddModelError("", "Erreur lors de la création du taux d'alerte.");
                }
            }
            return View(tauxAlerte);
        }
    }
}
