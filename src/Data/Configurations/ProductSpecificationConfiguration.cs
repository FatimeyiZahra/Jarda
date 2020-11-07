using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    class ProductSpecificationConfiguration : IEntityTypeConfiguration<ProductSpecification>
    {
        public void Configure(EntityTypeBuilder<ProductSpecification> builder)
        {
            builder
                 .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
               .HasOne<Product>(m => m.Product)
               .WithMany(m => m.ProductSpecifications)
               .HasForeignKey(m => m.ProductId);

            builder
              .HasOne<Specification>(m => m.Specification)
              .WithMany(m => m.ProductSpecifications)
              .HasForeignKey(m => m.SpecificationId);

            builder.ToTable("ProductSpecifications");
        }
    }
}
