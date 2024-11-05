using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Member1
{
    public int Idmem { get; set; }

    public int Idmg { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Member IdmemNavigation { get; set; } = null!;

    public virtual MemberGroup IdmgNavigation { get; set; } = null!;
}
