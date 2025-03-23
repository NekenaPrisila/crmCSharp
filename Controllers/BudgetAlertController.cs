using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRMSharp.Models;

namespace CRMSharp.Controllers;

public class BudgetAlertController : Controller
{
    private readonly BudgetAlertApiService _budgetAlertApiService;

    public BudgetAlertController(BudgetAlertApiService budgetAlertApiService)
    {
        _budgetAlertApiService = budgetAlertApiService;
    }

    public async Task<IActionResult> Index()
    {
        var alert = await _budgetAlertApiService.GetAlertThresholdAsync();
        return View(alert);
    }

    [HttpPost]
    public async Task<IActionResult> Update(double alertThreshold)
    {
        var updatedAlert = await _budgetAlertApiService.UpdateAlertThresholdAsync(alertThreshold);
        return RedirectToAction("Index");
    }
}