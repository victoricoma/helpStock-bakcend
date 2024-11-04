using HelpStockApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpStockApp.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletronicos"),
                new Category(3, "Acessórios"),
                new Category(4, "Móveis"),
                new Category(5, "Vestuário")
                );
        }
    }
}
