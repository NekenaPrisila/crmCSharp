using CRMSharp.Models;

namespace CRMSharp.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalTickets { get; set; }
        public int TotalLeads { get; set; }
        public int TotalCustomers { get; set; }

        public List<TriggerTicket>? Tickets { get; set; }
        public List<TriggerLead>? Leads { get; set; }
        public List<Customer>? Customers { get; set; }
        public double TotalExpenseTickets { get; set; }
        public double TotalExpenseLeads { get; set; }

        public double TotalBudgetCustomers { get; set; }
        public double TotalExpenseCustomers { get; set; }
    }
}