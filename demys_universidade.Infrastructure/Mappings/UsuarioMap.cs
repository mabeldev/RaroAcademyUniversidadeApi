using demys_universidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demys_universidade.Infrastructure.Mappings
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasOne(p => p.Curso)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(p => p.CursoId)
                .IsRequired();
            builder
                .HasOne(p => p.Endereco)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.Perfil).HasConversion(
                    prop => prop.ToString(),
                    prop => (Perfil)Enum.Parse(typeof(Perfil), prop)
                );
        }

    }
}
