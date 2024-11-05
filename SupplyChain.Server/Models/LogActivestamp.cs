using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class LogActivestamp
{
    public int Idla { get; set; }

    public int? Idsb { get; set; }

    public int? Idmem { get; set; }

    public string? Type { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Member? IdmemNavigation { get; set; }

    public virtual StampBatch? IdsbNavigation { get; set; }
}
