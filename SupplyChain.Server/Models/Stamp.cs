using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Stamp
{
    public int Idsta { get; set; }

    public int? Idsb { get; set; }

    public int? Idpro { get; set; }

    public string? Describe { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Product? IdproNavigation { get; set; }

    public virtual StampBatch? IdsbNavigation { get; set; }
}
