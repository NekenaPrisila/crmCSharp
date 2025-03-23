using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public partial class Expense
{
    public int Id { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public uint CustomerId { get; set; }

    public uint? TicketId { get; set; }

    public uint? LeadId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual TriggerLead? Lead { get; set; }

    public virtual TriggerTicket? Ticket { get; set; }
}
