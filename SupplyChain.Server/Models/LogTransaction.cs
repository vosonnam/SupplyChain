using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class LogTransaction
{
    public int Idlt { get; set; }

    public int? Ssccinput { get; set; }

    public int? Ssccoutput { get; set; }

    public int? Businesssender { get; set; }

    public string? Glnsender { get; set; }

    public int? Businessreciver { get; set; }

    public string? Glnreciver { get; set; }

    public int? Factoryfrom { get; set; }

    public string? Glnfrom { get; set; }

    public int? Fatoryto { get; set; }

    public string? Glnto { get; set; }

    public DateTime? Deliveryat { get; set; }

    public double? Quantity { get; set; }

    public double? Weigh { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public DateTime? Updateat { get; set; }

    public string? Updateby { get; set; }

    public virtual Business? Business { get; set; }

    public virtual Business? BusinessNavigation { get; set; }

    public virtual Factory? Factory { get; set; }

    public virtual Factory? FactoryNavigation { get; set; }

    public virtual CodeTransport? SsccinputNavigation { get; set; }

    public virtual CodeTransport? SsccoutputNavigation { get; set; }
}
