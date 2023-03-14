using System;
using System.Collections.Generic;

namespace SampleOData.Models;

public partial class Customer
{
    public int? Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public string? Tel { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime? Created { get; set; }
}