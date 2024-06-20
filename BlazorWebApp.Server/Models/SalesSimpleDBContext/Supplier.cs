using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class Supplier
{
    public int Suppkey { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Nationkey { get; set; }

    public string Phone { get; set; } = null!;

    public decimal AcctBal { get; set; }

    public string Comment { get; set; } = null!;

    public virtual ICollection<PartsSupp> PartsSupps { get; set; } = new List<PartsSupp>();
}
