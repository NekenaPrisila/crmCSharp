using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public partial class TempUser
{
    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? HireDate { get; set; }

    public string? CreatedAt { get; set; }

    public string? UpdatedAt { get; set; }

    public string? Username { get; set; }

    public string? Status { get; set; }

    public string? Token { get; set; }

    public string? IsPasswordSet { get; set; }

    public string? Roles { get; set; }
}
