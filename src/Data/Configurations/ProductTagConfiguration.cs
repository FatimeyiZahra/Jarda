using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder
               .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
               .HasOne<Product>(m => m.Product)
               .WithMany(m => m.ProductTags)
               .HasForeignKey(m => m.ProductId);

            builder
              .HasOne<Tag>(m => m.Tag)
              .WithMany(m => m.ProductTags)
              .HasForeignKey(m => m.TagId);

            builder.ToTable("ProductTags");
        }
    }
}
