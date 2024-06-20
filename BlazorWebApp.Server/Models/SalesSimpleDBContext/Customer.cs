using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class Customer
{
    public int CustKey { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int NationKey { get; set; }

    public string Phone { get; set; } = null!;

    public decimal AcctBal { get; set; }

    public string MktSegment { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
