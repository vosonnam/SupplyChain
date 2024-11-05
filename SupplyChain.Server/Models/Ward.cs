using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Ward
{
    public int Idc { get; set; }

    public int Idcy { get; set; }

    public int Iddis { get; set; }

    public int Idwa { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual District District { get; set; } = null!;
}
