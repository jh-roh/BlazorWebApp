using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class DmlMaster
{
    public int OrderKey { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? CustomerKey { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Note { get; set; }
}
