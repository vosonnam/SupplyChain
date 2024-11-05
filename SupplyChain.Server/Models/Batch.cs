using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Batch
{
    public int Idbat { get; set; }

    public int? Idbus { get; set; }

    public string? Gln { get; set; }

    public int? Material { get; set; }

    public string? Name { get; set; }

    public string? Backingspecification { get; set; }

    public double? Quantity { get; set; }

    public double? Weigh { get; set; }

    public string? Unit { get; set; }

    public DateTime? Dfg { get; set; }

    public DateTime? Exp { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Business? Business { get; set; }

    public virtual ICollection<CodeTransport> CodeTransports { get; set; } = new List<CodeTransport>();

    public virtual ICollection<DiaryActivity> DiaryActivities { get; set; } = new List<DiaryActivity>();

    public virtual ICollection<Batch> InverseMaterialNavigation { get; set; } = new List<Batch>();

    public virtual Batch? MaterialNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
