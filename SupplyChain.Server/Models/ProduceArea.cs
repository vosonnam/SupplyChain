using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class ProduceArea
{
    public int Idpa { get; set; }

    public int? Iddoc { get; set; }

    public int? Idadd { get; set; }

    public string? Gln { get; set; }

    public string? Name { get; set; }

    public string? Sector { get; set; }

    public double? Acreage { get; set; }

    public double? Production { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Address? IdaddNavigation { get; set; }

    public virtual Document? IddocNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
