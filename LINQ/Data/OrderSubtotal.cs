﻿using System;
using System.Collections.Generic;

namespace LINQ.Data;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
