using System;
using System.Text.Json.Serialization;
using Liquid.Repository;

namespace TdcFuture.Domain.Entities
{
    public class ShoppingCartProduct : LiquidEntity<int>
    {
        public int ShoppingCartId { get; set; }
        [JsonIgnore]
        public ShoppingCart ShoppingCart { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedToCart { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
