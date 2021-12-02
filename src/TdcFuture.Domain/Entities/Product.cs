using Liquid.Repository;

namespace TdcFuture.Domain.Entities
{
    public class Product : LiquidEntity<int>
    {
        public string Name { get; set;}
        public string Description { get; set; }
    }
}
