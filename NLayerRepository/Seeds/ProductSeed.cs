using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //burada veri tabanı oluşurken oluşturacağımız default değerleri ekliyoruz. Örn;
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "ASUS ROG 15.6'",
                Price = 120,
                Stock = 20,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 2,
                CategoryId = 2,
                Name = "Microsot Surface",
                Price = 80,
                Stock = 200,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 3,
                CategoryId = 3,
                Name = "32inch LG gaming monitor 144hz",
                Price = 80,
                Stock = 200,
                CreatedDate = DateTime.Now
            });

        }
    }
}