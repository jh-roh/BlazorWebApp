using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class Part
{
    public int PartKey { get; set; }

    public string Name { get; set; } = null!;

    public string Mfgr { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Size { get; set; }

    public string Container { get; set; } = null!;

    public decimal RetailPrice { get; set; }

    public string Comment { get; set; } = null!;

    public virtual ICollection<PartsSupp> PartsSupps { get; set; } = new List<PartsSupp>();
}
