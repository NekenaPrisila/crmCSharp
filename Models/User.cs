using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Username { get; set; } = null!;

    public string? Status { get; set; }

    public string? Token { get; set; }

    public bool? IsPasswordSet { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<TriggerLead> TriggerLeadEmployees { get; set; } = new List<TriggerLead>();

    public virtual ICollection<TriggerLead> TriggerLeadUsers { get; set; } = new List<TriggerLead>();

    public virtual ICollection<TriggerTicket> TriggerTicketEmployees { get; set; } = new List<TriggerTicket>();

    public virtual ICollection<TriggerTicket> TriggerTicketManagers { get; set; } = new List<TriggerTicket>();
}
