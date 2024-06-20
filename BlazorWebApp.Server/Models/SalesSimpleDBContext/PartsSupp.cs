using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class PartsSupp
{
    public int PartKey { get; set; }

    public int SuppKey { get; set; }

    public int AvailQty { get; set; }

    public decimal SupplyCost { get; set; }

    public string Comment { get; set; } = null!;

    public virtual ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();

    public virtual Part PartKeyNavigation { get; set; } = null!;

    public virtual Supplier SuppKeyNavigation { get; set; } = null!;
}
