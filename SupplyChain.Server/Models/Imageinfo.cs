using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Imageinfo
{
    public string Idimg { get; set; } = null!;

    public string? Type { get; set; }

    public string? Tittle { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }
}
