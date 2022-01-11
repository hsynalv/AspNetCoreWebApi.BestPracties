using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNlayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] id)
        {
            _ids = id;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50M, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Kurşun Kalem", Price = 40.50M, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Tükenmez Kalem", Price = 500M, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Küçük Boy Defter", Price = 12.50M, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "Orta Boy Defter", Price = 27.50M, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 6, Name = "Büyük Boy Defter", Price = 12.50M, Stock = 100, CategoryId = _ids[1] }
                );
        }
    }
}
