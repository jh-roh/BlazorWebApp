using System;
using System.Collections.Generic;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class LineItem
{
    public int OrderKey { get; set; }

    public int PartKey { get; set; }

    public int SuppKey { get; set; }

    public int LineNumber { get; set; }

    public decimal Quantity { get; set; }

    public decimal ExtendedPrice { get; set; }

    public decimal Discount { get; set; }

    public decimal Tax { get; set; }

    public string ReturnFlag { get; set; } = null!;

    public string LineStatus { get; set; } = null!;

    public DateTime ShipDate { get; set; }

    public DateTime CommitDate { get; set; }

    public DateTime ReceiptDate { get; set; }

    public string ShipinStruct { get; set; } = null!;

    public string ShipMode { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public virtual Order OrderKeyNavigation { get; set; } = null!;

    public virtual PartsSupp PartsSupp { get; set; } = null!;
}
