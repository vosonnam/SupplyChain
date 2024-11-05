using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class DiaryTransport
{
    public int Iddt { get; set; }

    public int? Idct { get; set; }

    public int? Idmem { get; set; }

    public string? Status { get; set; }

    public DateTime? Departtime { get; set; }

    public DateTime? Arrivetime { get; set; }

    public string? Note { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual CodeTransport? IdctNavigation { get; set; }

    public virtual Member? IdmemNavigation { get; set; }
}
