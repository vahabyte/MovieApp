﻿using System;
using System.Collections.Generic;

namespace LINQ.Data;

public partial class Shipper
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; }

    public string Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
