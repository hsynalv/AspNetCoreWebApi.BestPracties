using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNlayerProject.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).IsRequired().HasMaxLength(250);

            builder.Property(I => I.Stock).IsRequired();

            builder.Property(I=>I.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(I => I.InnerBarcode).HasMaxLength(50);

            builder.ToTable("Products");
        }
    }
}
