using Crm.Domain.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Sobrenome)
                .HasColumnName("Sobrenome")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(x => x.Login)
                .HasColumnName("Login")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(x => x.Celular)
                .HasColumnName("Celular")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(x => x.TipoUsuario)
                .HasColumnName("TipoUsuario")
                .HasColumnType("int")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.Sexo)
                .HasColumnName("Sexo")
                .HasColumnType("int")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetDate()")
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}