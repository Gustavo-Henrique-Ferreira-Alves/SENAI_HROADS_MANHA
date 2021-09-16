using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class HROADSContext : DbContext
    {
        public HROADSContext()
        {
        }

        public HROADSContext(DbContextOptions<HROADSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__CLASSE__60FFF80163EEA1E3");

                entity.ToTable("CLASSE");

                entity.HasIndex(e => e.NomeClasse, "UQ__CLASSE__F1ED810200CDD147")
                    .IsUnique();

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("nomeClasse");
            });

            modelBuilder.Entity<ClasseHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdClasseHab)
                    .HasName("PK__CLASSE_H__77E64E4AB5DDCC7C");

                entity.ToTable("CLASSE_HABILIDADE");

                entity.Property(e => e.IdClasseHab).HasColumnName("idClasseHab");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__CLASSE_HA__idCla__4316F928");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__CLASSE_HA__idHab__440B1D61");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__HABILIDA__655F7528F10ABF37");

                entity.ToTable("HABILIDADE");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHab).HasColumnName("idTipoHab");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeHabilidade");

                entity.HasOne(d => d.IdTipoHabNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHab)
                    .HasConstraintName("FK__HABILIDAD__idTip__403A8C7D");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__PERSONAG__E175C72EC6BF7C3F");

                entity.ToTable("PERSONAGEM");

                entity.HasIndex(e => e.NomePersonagem, "UQ__PERSONAG__2075C7B8B870653F")
                    .IsUnique();

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("dataAtualizacao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("date")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__PERSONAGE__idCla__3A81B327");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHab)
                    .HasName("PK__TIPO_HAB__FD3EC2548F4B4078");

                entity.ToTable("TIPO_HABILIDADE");

                entity.HasIndex(e => e.NomeTipoHab, "UQ__TIPO_HAB__98422FA335D04BA7")
                    .IsUnique();

                entity.Property(e => e.IdTipoHab).HasColumnName("idTipoHab");

                entity.Property(e => e.NomeTipoHab)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoHab");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUser)
                    .HasName("PK__TIPO_USU__39DB342F804D17B3");

                entity.ToTable("TIPO_USUARIO");

                entity.HasIndex(e => e.Titulo, "UQ__TIPO_USU__38FA640FEE0C5AB3")
                    .IsUnique();

                entity.Property(e => e.IdTipoUser).HasColumnName("idTipoUser");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A69BD2E80B");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E6164512D7141")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUser).HasColumnName("idTipoUser");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("senha")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdTipoUserNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUser)
                    .HasConstraintName("FK__USUARIO__idTipoU__0F624AF8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
