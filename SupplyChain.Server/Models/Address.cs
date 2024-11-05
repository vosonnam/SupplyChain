using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Address
{
    public int Idadd { get; set; }

    public int Idc { get; set; }

    public int Idcy { get; set; }

    public int Iddis { get; set; }

    public int Idwa { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public string Gln { get; set; } = null!;

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();

    public virtual ICollection<Factory> Factories { get; set; } = new List<Factory>();

    public virtual ICollection<ProduceArea> ProduceAreas { get; set; } = new List<ProduceArea>();

    public virtual Ward Ward { get; set; } = null!;
}
