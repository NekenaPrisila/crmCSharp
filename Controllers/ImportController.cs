using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

public class ImportController : Controller
{
    private readonly ILogger<ImportController> _logger;
    private readonly CustomerService _customerService;

    public ImportController(ILogger<ImportController> logger, CustomerService customerImportService)
    {
        _logger = logger;
        _customerService = customerImportService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> JsonImport()
    {
        try
        {
            var file = Request.Form.Files["fileCustomerJson"];
            
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Veuillez sélectionner un fichier valide.");
                return View("Index");
            }

            if (!file.FileName.EndsWith(".json"))
            {
                ModelState.AddModelError("", "Seuls les fichiers JSON sont autorisés.");
                return View("Index");
            }

            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                var jsonContent = await streamReader.ReadToEndAsync();
                var result = await _customerService.ImportCustomerJson(jsonContent);

                if (result)
                {
                    TempData["SuccessMessage"] = "Importation réussie!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Erreur lors de l'importation du fichier.");
                    return View("Index");
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de l'importation du fichier JSON");
            ModelState.AddModelError("", "Une erreur est survenue lors de l'importation.");
            return View("Index");
        }
    }
}