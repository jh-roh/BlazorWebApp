using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class Blob
{
    public int Id { get; set; }

    public string Lob { get; set; } = null!;
}
