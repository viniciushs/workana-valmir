namespace BackEnd.Infra.Data.Contexts
{
    using BackEnd.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class BackEndContext : DbContext
    {
        // Scaffold-DbContext "Data Source=VINICIUS-DELL\SQLEXPRESS;Initial Catalog=projetoTestexxx;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -Context "BackEndContext" -ContextDir "DatabaseFirst/Context" -OutputDir "DatabaseFirst/Models" -f
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<FormaPagto> FormaPagto { get; set; }
        public virtual DbSet<Franqueado> Franqueado { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Situacao> Situacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.HasIndex(e => e.DescricaoCargo)
                    .HasName("AK_Cargo_Descricao")
                    .IsUnique();

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.DescricaoCargo)
                    .IsRequired()
                    .HasColumnName("descricaoCargo")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormaPagto>(entity =>
            {
                entity.HasKey(e => e.IdFormaPagto);

                entity.Property(e => e.DescricaoFormaPagto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Franqueado>(entity =>
            {
                entity.HasKey(e => e.IdFranqueado);

                entity.Property(e => e.IdFranqueado).HasColumnName("idFranqueado");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("dataCadastro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataCancelamento)
                    .HasColumnName("dataCancelamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoFranqueado)
                    .IsRequired()
                    .HasColumnName("descricaoFranqueado")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Franqueado)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Franqueado_Situacao");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario);

                entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("dataCadastro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoFuncionario)
                    .IsRequired()
                    .HasColumnName("descricaoFuncionario")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFranqueadoNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdFranqueado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Franqueado");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Situacao");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao);

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.DescricaoSituacao)
                    .IsRequired()
                    .HasColumnName("descricaoSituacao")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("BackEndConnection"));
        }
    }
}
