using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class StampBatch
{
    public int Idsb { get; set; }

    public int? Idso { get; set; }

    public string? Tittle { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual StampOrder? IdsoNavigation { get; set; }

    public virtual ICollection<LogActivestamp> LogActivestamps { get; set; } = new List<LogActivestamp>();

    public virtual ICollection<Stamp> Stamps { get; set; } = new List<Stamp>();
}
