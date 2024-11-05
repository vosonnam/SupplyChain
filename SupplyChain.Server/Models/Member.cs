using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Member
{
    public int Idmem { get; set; }

    public int? Hostbusiness { get; set; }

    public string? Gln { get; set; }

    public string? Name { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Business? Business { get; set; }

    public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();

    public virtual ICollection<DiaryActivity> DiaryActivities { get; set; } = new List<DiaryActivity>();

    public virtual ICollection<DiaryCategory> DiaryCategories { get; set; } = new List<DiaryCategory>();

    public virtual ICollection<DiaryTransport> DiaryTransports { get; set; } = new List<DiaryTransport>();

    public virtual ICollection<LogActivestamp> LogActivestamps { get; set; } = new List<LogActivestamp>();

    public virtual ICollection<LogScan> LogScans { get; set; } = new List<LogScan>();

    public virtual ICollection<Member1> Member1s { get; set; } = new List<Member1>();

    public virtual ICollection<ShareRequest> ShareRequests { get; set; } = new List<ShareRequest>();

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
