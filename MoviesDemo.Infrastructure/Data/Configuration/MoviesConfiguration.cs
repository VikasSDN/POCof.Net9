using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesDemo.Core.Entities;

namespace MoviesDemo.Infrastructure.Data.Configuration
{
    public class MoviesConfiguration : IEntityTypeConfiguration<MoviesEntity>
    {
        public void Configure(EntityTypeBuilder<MoviesEntity> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.ReleaseYear)
                .IsRequired();

            builder.Property(x => x.posterImagePath)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
