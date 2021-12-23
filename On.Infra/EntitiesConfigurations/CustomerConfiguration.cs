using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using On.Core.Entites;
using On.Domain.Entites;

namespace On.Infra.EntitiesConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.OwnsOne(c => c.Address, a =>
              {
                  a.Property(p => p.State)
                  .HasColumnName("state")
                  .HasDefaultValue("");

                  a.Property(p => p.Country)
                  .HasColumnName("country")
                  .HasDefaultValue("");

                  a.Property(p => p.Zipcode)
                  .HasColumnName("zip_code")
                  .HasDefaultValue("");

                  a.Property(p => p.Street)
                  .HasColumnName("street")
                  .HasDefaultValue("");

                  a.Property(p => p.City)
                 .HasColumnName("city")
                 .HasDefaultValue("");
              });

            builder.OwnsMany(c => c.CustomerPhotos, cfg =>
             {
                 cfg.Property(c => c.Id)
                 .HasColumnName("id")
                   .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()");

                 cfg.Property(c => c.PathUrl)
                 .HasColumnName("path_url");

                 cfg.Property(c => c.Alt)
                 .HasColumnName("alt");

             });

            builder.Metadata.FindNavigation(nameof(Customer.CustomerPhotos))
                .SetField("_photos");



        }
    }

}