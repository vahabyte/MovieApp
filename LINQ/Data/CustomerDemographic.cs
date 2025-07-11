﻿using System;
using System.Collections.Generic;

namespace LINQ.Data;

public partial class CustomerDemographic
{
    public string CustomerTypeId { get; set; }

    public string CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
