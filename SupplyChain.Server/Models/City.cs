using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class City
{
    public int Idc { get; set; }

    public int Idcy { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual Country IdcNavigation { get; set; } = null!;
}
