using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class ShareRequest
{
    public int Idsr { get; set; }

    public int? Idmem { get; set; }

    public string? Tittle { get; set; }

    public string? Describe { get; set; }

    public string? Status { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Member? IdmemNavigation { get; set; }
}
