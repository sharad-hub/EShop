using Shop.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shop.Data.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductID);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.QuantityPerUnit)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.UnitsInStock).HasColumnName("UnitsInStock");
            this.Property(t => t.UnitsOnOrder).HasColumnName("UnitsOnOrder");
            this.Property(t => t.ReorderLevel).HasColumnName("ReorderLevel");
            this.Property(t => t.Discontinued).HasColumnName("Discontinued");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.CategoryID);
            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.SupplierID);

            this.HasOptional(t => t.ProductLabel)
           .WithMany(t => t.Products)
           .HasForeignKey(d => d.ProductLabelId);

            this.HasOptional(t => t.CategoriesToShow)
          .WithMany(t => t.Products)
          .HasForeignKey(d => d.CategoriesToShowId);

            // Relationships
            this.HasMany(t => t.ProductTags)
                .WithMany(t => t.Products)
                .Map(m =>
                {
                    m.ToTable("ProductsTagMappings");
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("ProductTagID");
                });

            this.HasMany(t => t.DiscountsAvailable)
                .WithMany(t => t.Products)
                .Map(m =>
                {
                    m.ToTable("ProductsDiscountMappings");
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("DiscountID");
                });

        }
    }
}
