using System;
using System.Collections.Generic;
using Liquid.Repository;

namespace TdcFuture.Domain.Entities
{
    public class ShoppingCart : LiquidEntity<int>
    {
        public int TotalItems { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public List<ShoppingCartProduct> Products { get; set; }

    }
}
