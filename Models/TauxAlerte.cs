using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public partial class TauxAlerte
{
    public int Id { get; set; }

    public decimal Taux { get; set; }

    public DateTime DateChangement { get; set; }
}
