using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class LogScan
{
    public int Idlc { get; set; }

    public int? Idmem { get; set; }

    public string? Describe { get; set; }

    public string? Type { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Member? IdmemNavigation { get; set; }
}
