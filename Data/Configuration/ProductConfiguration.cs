using Model;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");
            Property(p => p.Name).IsRequired().HasMaxLength(50);
            Property(p => p.Price).IsRequired().HasPrecision(8, 2);
            Property(p => p.CategoryID).IsRequired();
        }
    }
}
