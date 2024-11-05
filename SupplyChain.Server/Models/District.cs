using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class District
{
    public int Idc { get; set; }

    public int Idcy { get; set; }

    public int Iddis { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
