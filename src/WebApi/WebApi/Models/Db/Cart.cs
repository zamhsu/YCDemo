using System;
using System.Collections.Generic;

namespace WebApi.Models.Db
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
