using System;
using System.Collections.Generic;

namespace WebApi.Models.Db
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ItemNo { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
