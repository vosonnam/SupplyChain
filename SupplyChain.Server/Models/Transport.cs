using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Transport
{
    public int Idtra { get; set; }

    public int? Hostunit { get; set; }

    public string? Gln { get; set; }

    public int? License { get; set; }

    public int? Vehicleowner { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Vehicle { get; set; }

    public string? Phonenumber { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Business? Business { get; set; }

    public virtual ICollection<CodeTransport> CodeTransports { get; set; } = new List<CodeTransport>();

    public virtual Document? LicenseNavigation { get; set; }

    public virtual Member? VehicleownerNavigation { get; set; }
}
