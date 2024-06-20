using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class Nation
{
    public int NationKey { get; set; }

    public string Name { get; set; } = null!;

    public int RegionKey { get; set; }

    public string? Comment { get; set; }

    public virtual Region RegionKeyNavigation { get; set; } = null!;
}
