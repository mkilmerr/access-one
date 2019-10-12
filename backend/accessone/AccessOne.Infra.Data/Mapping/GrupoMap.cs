using AccessOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessOne.Infra.Data.Mapping
{
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("Grupo");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Nome)
                    .IsRequired()
                    .HasColumnName("Nome");
        }
    }
}
