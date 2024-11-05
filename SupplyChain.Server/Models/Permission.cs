using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Permission
{
    public int Idpm { get; set; }

    public int? Idpg { get; set; }

    public string? Describe { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual PermissionGroup? IdpgNavigation { get; set; }
}
