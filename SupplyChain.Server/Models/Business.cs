using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Business
{
    public int Idbus { get; set; }

    public int Idmem { get; set; }

    public int? Iddoc { get; set; }

    public int? Idadd { get; set; }

    public string Gln { get; set; } = null!;

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Taxcode { get; set; }

    public string? Phonenumber { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual Address? IdaddNavigation { get; set; }

    public virtual Document? IddocNavigation { get; set; }

    public virtual Member IdmemNavigation { get; set; } = null!;

    public virtual ICollection<LogTransaction> LogTransactionBusinessNavigations { get; set; } = new List<LogTransaction>();

    public virtual ICollection<LogTransaction> LogTransactionBusinesses { get; set; } = new List<LogTransaction>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<StampOrder> StampOrders { get; set; } = new List<StampOrder>();

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();

    public virtual ICollection<Product> Idpros { get; set; } = new List<Product>();
}
