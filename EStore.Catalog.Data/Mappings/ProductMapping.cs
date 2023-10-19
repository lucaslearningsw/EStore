using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.Catalog.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(400)");

            builder.Property(c => c.Image)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(c => c.Dimensions, cm =>
            {
                cm.Property(c => c.Height)
                    .HasColumnName("Height")
                    .HasColumnType("int");

                cm.Property(c => c.Width)
                    .HasColumnName("Width")
                    .HasColumnType("int");

                cm.Property(c => c.Profundity)
                    .HasColumnName("Profundity")
                    .HasColumnType("int");
            });

            builder.ToTable("Products");


        }
    }
}
