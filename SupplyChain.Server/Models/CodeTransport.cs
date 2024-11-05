using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class CodeTransport
{
    public int Idct { get; set; }

    public int? Idtra { get; set; }

    public int? Idbat { get; set; }

    public double? Quantity { get; set; }

    public double? Weigh { get; set; }

    public string? Backingspecification { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual ICollection<DiaryTransport> DiaryTransports { get; set; } = new List<DiaryTransport>();

    public virtual Batch? IdbatNavigation { get; set; }

    public virtual Transport? IdtraNavigation { get; set; }

    public virtual ICollection<LogTransaction> LogTransactionSsccinputNavigations { get; set; } = new List<LogTransaction>();

    public virtual ICollection<LogTransaction> LogTransactionSsccoutputNavigations { get; set; } = new List<LogTransaction>();
}
