using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public partial class TriggerLead
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string Customer { get; set; }
    public string AssignedEmployee { get; set; }
    public DateTime CreatedAt { get; set; }
    public double Expense { get; set; }

}
