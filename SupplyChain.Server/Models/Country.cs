using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Country
{
    public int Idc { get; set; }

    public string? Name { get; set; }

    public string? Continent { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
