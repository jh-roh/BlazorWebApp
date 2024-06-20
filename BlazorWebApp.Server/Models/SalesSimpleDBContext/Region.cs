using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class Region
{
    public int RegionKey { get; set; }

    public string Name { get; set; } = null!;

    public string? Comment { get; set; }

    public virtual ICollection<Nation> Nations { get; set; } = new List<Nation>();
}
