using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class Order
{
    public int OrderKey { get; set; }

    public int CustKey { get; set; }

    public string OrderStatus { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public DateTime OrderDate { get; set; }

    public string OrderPriority { get; set; } = null!;

    public string Clerk { get; set; } = null!;

    public int ShipPriority { get; set; }

    public string Comment { get; set; } = null!;

    public virtual Customer CustKeyNavigation { get; set; } = null!;

    public virtual ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();
}
