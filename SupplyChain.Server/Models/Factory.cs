using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Factory
{
    public int Idfac { get; set; }

    public int? Iddoc { get; set; }

    public int? Idadd { get; set; }

    public string Gln { get; set; } = null!;

    public string? Name { get; set; }

    public double? Acreagetotal { get; set; }

    public double? Warehousearea { get; set; }

    public double? Wattage { get; set; }

    public string? Type { get; set; }

    public string? Sector { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Address? IdaddNavigation { get; set; }

    public virtual Document? IddocNavigation { get; set; }

    public virtual ICollection<LogTransaction> LogTransactionFactories { get; set; } = new List<LogTransaction>();

    public virtual ICollection<LogTransaction> LogTransactionFactoryNavigations { get; set; } = new List<LogTransaction>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
