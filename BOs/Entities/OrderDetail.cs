﻿using System;
using System.Collections.Generic;

namespace BOs.Entities;

public partial class OrderDetail
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int Price { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
