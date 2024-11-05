using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class DiaryActivity
{
    public int Idda { get; set; }

    public int? Idmem { get; set; }

    public int? Idbat { get; set; }

    public string? Type { get; set; }

    public string? Name { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Batch? IdbatNavigation { get; set; }

    public virtual Member? IdmemNavigation { get; set; }
}
