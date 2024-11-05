using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Product
{
    public int Idpro { get; set; }

    public int? Idbat { get; set; }

    public int? Idpa { get; set; }

    public int? Idcg { get; set; }

    public int? Idfac { get; set; }

    public string? Gln { get; set; }

    public int? Iddoc { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Describe { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Factory? Factory { get; set; }

    public virtual Batch? IdbatNavigation { get; set; }

    public virtual Category? IdcgNavigation { get; set; }

    public virtual Document? IddocNavigation { get; set; }

    public virtual ProduceArea? IdpaNavigation { get; set; }

    public virtual ICollection<Stamp> Stamps { get; set; } = new List<Stamp>();

    public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();
}
