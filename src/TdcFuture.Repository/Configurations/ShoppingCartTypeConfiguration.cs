using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TdcFuture.Domain.Entities;

namespace TdcFuture.Repository.Configurations
{
    public class ShoppingCartTypeConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.Property(o => o.Id).ValueGeneratedOnAdd(); 
            builder.Property(o => o.Created).IsRequired().HasDefaultValueSql("now()");
            builder.Property(o => o.LastUpdated).IsRequired().HasDefaultValueSql("now()");
            builder.Property(o => o.TotalAmount).IsRequired();
            builder.Property(o => o.TotalItems).IsRequired();

            builder.HasMany(o => o.Products).WithOne(o => o.ShoppingCart).HasForeignKey(o => o.ShoppingCartId).IsRequired().OnDelete(DeleteBehavior.Cascade);



            builder.ToTable("ShoppingCart").HasKey(o => o.Id);
        }
    }
}
