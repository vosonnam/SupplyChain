using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class StampOrder
{
    public int Idso { get; set; }

    public int? Idbus { get; set; }

    public string? Gln { get; set; }

    public string? Tittleso { get; set; }

    public DateTime? Fromdateso { get; set; }

    public DateTime? Todateso { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Business? Business { get; set; }

    public virtual ICollection<StampBatch> StampBatches { get; set; } = new List<StampBatch>();
}
