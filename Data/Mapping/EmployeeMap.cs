using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SorveSoftApi.Models;

namespace SorveSoftApi.Data.Mapping
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Define o nome da tabela
            builder.ToTable("TB_Employee");

            // Configuração da chave primária
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            // Configuração das propriedades
            builder.Property(e => e.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(e => e.Position)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(e => e.Registration)
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsRequired(false); 

            builder.Property(e => e.IsActive)
                .IsRequired();

            // Configuração de propriedades de auditoria
            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate();

            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.Registration).IsUnique();
        }
    }
}
