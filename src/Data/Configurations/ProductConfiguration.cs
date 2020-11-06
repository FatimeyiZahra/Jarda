using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                    .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
              .Property(m => m.Status)
              .IsRequired()
              .HasDefaultValue(true);

            builder
                .Property(m => m.Name)
                .HasMaxLength(150)
                .IsRequired();
            builder
              .Property(m => m.Developer)
              .HasMaxLength(150)
              .IsRequired();
            builder
              .Property(m => m.Publisher)
              .HasMaxLength(150)
              .IsRequired();

            builder
               .Property(m => m.ReleaseDate)
               .IsRequired();

            builder
               .Property(m => m.Video)
               .HasMaxLength(100)
               .IsRequired();

            builder
              .Property(m => m.Publisher)
              .HasMaxLength(150)
              .IsRequired();

            builder
                .HasOne(m => m.Category)
                .WithMany(m => m.Products)
                .HasForeignKey(m => m.CategoryId);

            builder
             .Property(m => m.IsComing)
             .IsRequired()
             .HasDefaultValue(false);

            builder
            .Property(m => m.IsFree)
            .IsRequired()
            .HasDefaultValue(false);

            builder
            .Property(m => m.IsNew)
            .IsRequired()
            .HasDefaultValue(false);

            builder
             .Property(m => m.IsTopSeller)
             .IsRequired()
             .HasDefaultValue(false);

            builder
                .Property(m => m.Desc)
                .HasMaxLength(500)
                .IsRequired();

            builder
               .Property(m => m.Desc)
               .HasColumnType("ntext");

            builder.ToTable("Products");
        }
    }
}
