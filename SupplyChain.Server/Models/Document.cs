using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Document
{
    public int Iddoc { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Describe { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();

    public virtual ICollection<Factory> Factories { get; set; } = new List<Factory>();

    public virtual ICollection<ProduceArea> ProduceAreas { get; set; } = new List<ProduceArea>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
