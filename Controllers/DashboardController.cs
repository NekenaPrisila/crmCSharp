using Microsoft.AspNetCore.Mvc;
using CRMSharp.ViewModels;

public class DashboardController : Controller
{
    
    private readonly TicketsService _ticketService;
    private readonly LeadService _leadService;
    private readonly CustomerService _customerService;

    public DashboardController(TicketsService ticketService, LeadService leadService, CustomerService customerService)
    {
        _ticketService = ticketService;
        _leadService = leadService;
        _customerService = customerService;
    }

    public async Task<ActionResult> Index()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        var leads = await _leadService.GetAllLeadsAsync();
        var customers = await _customerService.GetAllCustomersAsync();

        // Créer le modèle avec les données récupérées
        var model = new DashboardViewModel
        {
            TotalTickets = tickets.Count, // Maintenant, tickets est une List<Ticket>
            TotalLeads = leads.Count,     // Maintenant, leads est une List<Lead>
            TotalCustomers = customers.Count, // Maintenant, customers est une List<Customer>
            Tickets = tickets,
            Leads = leads,
            Customers = customers
        };

        return View(model);
    }

    public async Task<IActionResult> DeleteTicket(int id)
    {
        var result = await _ticketService.DeleteTicketAsync(id);
        
        if (result)
        {
            // Redirige vers l'index si la suppression a réussi
            return RedirectToAction(nameof(Index));
        }
        else
        {
            // Retourne une vue d'erreur ou un message d'erreur si la suppression a échoué
            TempData["ErrorMessage"] = "Une erreur s'est produite lors de la suppression du ticket.";
            return RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> DeleteLead(int id)
    {
        var result = await _leadService.DeleteLeadAsync(id);
        
        if (result)
        {
            // Redirige vers l'index si la suppression a réussi
            return RedirectToAction(nameof(Index));
        }
        else
        {
            // Retourne une vue d'erreur ou un message d'erreur si la suppression a échoué
            TempData["ErrorMessage"] = "Une erreur s'est produite lors de la suppression du lead.";
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTicketExpense([FromBody] UpdateExpenseRequest request)
    {
        var success = await _ticketService.UpdateTicketExpenseAsync(request.Id, request.Expense);
        if (!success)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateLeadExpense([FromBody] UpdateExpenseRequest request)
    {
        var success = await _leadService.UpdateLeadExpenseAsync(request.Id, request.Expense);
        if (!success)
        {
            return NotFound();
        }

        return Ok();
    }

    public class UpdateExpenseRequest
    {
        public int Id { get; set; }
        public decimal Expense { get; set; }
    }

}
