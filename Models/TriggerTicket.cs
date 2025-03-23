using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public partial class TriggerTicket
{
        public uint Id { get; set; }
        public string Subject { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Customer { get; set; }
        public string AssignedEmployee { get; set; }
        public double Expense { get; set; }
}