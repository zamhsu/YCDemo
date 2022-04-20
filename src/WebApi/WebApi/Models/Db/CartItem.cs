﻿using System;
using System.Collections.Generic;

namespace WebApi.Models.Db
{
    public partial class CartItem
    {
        public int CartId { get; set; }
        public int ItemNo { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
