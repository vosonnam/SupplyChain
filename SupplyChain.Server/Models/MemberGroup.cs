using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class MemberGroup
{
    public int Idmg { get; set; }

    public string? Type { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<Member1> Member1s { get; set; } = new List<Member1>();
}
