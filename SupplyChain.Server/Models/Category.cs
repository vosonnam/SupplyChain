using System;
using System.Collections.Generic;

namespace SupplyChain.Server.Models;

public partial class Category
{
    public int Idcg { get; set; }

    public int? CatIdcg { get; set; }

    public int? Idbus { get; set; }

    public string? Gln { get; set; }

    public string? Name { get; set; }

    public string? Describe { get; set; }

    public DateTime? Createat { get; set; }

    public string? Createby { get; set; }

    public virtual Business? Business { get; set; }

    public virtual Category? CatIdcgNavigation { get; set; }

    public virtual ICollection<Category> InverseCatIdcgNavigation { get; set; } = new List<Category>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
