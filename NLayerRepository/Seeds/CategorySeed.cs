using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) 
        {
            //burada veri tabanı oluşurken oluşturacağımız default değerleri ekliyoruz. Örn;
            builder.HasData(new Category { Id = 1, Name = "Gaming Computers" });
            builder.HasData(new Category { Id = 2, Name = "Office Computers" });
            builder.HasData(new Category { Id = 2, Name = "Monitors" });

        }
    }
}
