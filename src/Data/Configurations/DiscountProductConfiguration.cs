using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    class DiscountProductConfiguration : IEntityTypeConfiguration<DiscountProduct>
    {
        public void Configure(EntityTypeBuilder<DiscountProduct> builder)
        {
            builder
              .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(m => m.Discount)
                .WithMany(m => m.Products)
                .HasForeignKey(m => m.DiscountId);

            builder
                .HasOne(m => m.Product)
                .WithMany(m => m.Discounts)
                .HasForeignKey(m => m.ProductId);

            builder.ToTable("DiscountProducts");
        }
    }
}
