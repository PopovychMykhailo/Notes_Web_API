using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfigurations
{
    internal class ApiVersionConfiguration : IEntityTypeConfiguration<ApiVersion>
    {
        public void Configure(EntityTypeBuilder<ApiVersion> builder)
        {
            builder.HasKey(v => v.Id);
            builder.HasIndex(v => v.Id).IsUnique();
            builder.HasIndex(v => v.Version).IsUnique();
            builder.Property(v => v.Description).IsRequired().HasMaxLength(5000);
        }
    }
}
