using System;
using System.Collections.Generic;

namespace Lab13_RamiroSuico.Domain.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
