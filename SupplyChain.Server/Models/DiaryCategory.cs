using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class DiaryCategory
{
    public int Iddc { get; set; }

    public int? Idmem { get; set; }

    public string? Describe { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Member? IdmemNavigation { get; set; }
}
