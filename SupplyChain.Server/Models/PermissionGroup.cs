using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class PermissionGroup
{
    public int Idpg { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
