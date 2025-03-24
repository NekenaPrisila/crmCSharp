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
        return View();
    }

    // Traiter la soumission du formulaire
    [HttpPost]
    public async Task<IActionResult> CreateTaux(TauxAlerte tauxAlerte)
    {
        if (ModelState.IsValid)
        {
            bool result = await _tauxAlerteService.CreateTauxAlerteAsync(tauxAlerte);
            if (result)
            {
                TempData["SuccessMessage"] = "Taux d'alerte créé avec succès !";
                return RedirectToAction("Index", "Home"); // Rediriger vers la page d'accueil
            }
            else
            {
                ModelState.AddModelError("", "Erreur lors de la création du taux d'alerte.");
            }
        }
        return View(tauxAlerte);
    }
}
