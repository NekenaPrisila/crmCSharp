using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public class Expense
{
    public int Id { get; set; }

    public double Amount { get; set; }

    public string Description { get; set; }

    public int Customer { get; set; }

}
