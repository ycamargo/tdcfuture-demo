using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TdcFuture.Domain.Entities;

namespace TdcFuture.Repository.Configurations
{
    public class ShoppingCartProductTypeConfiguration : IEntityTypeConfiguration<ShoppingCartProduct>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartProduct> builder)
        {
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Price).IsRequired();
            builder.Property(o => o.Quantity).IsRequired();
            builder.Property(o => o.LastUpdated).IsRequired().HasDefaultValueSql("now()");
            builder.Property(o => o.AddedToCart).IsRequired().HasDefaultValueSql("now()");

            builder.HasOne(o => o.Product).WithMany().HasForeignKey(o => o.ProductId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            
            builder.ToTable("ShoppingCartProduct").HasKey(o => o.Id);
        }
    }
}
