using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webAPI.Domains;

#nullable disable

namespace senai.hroads.webAPI.Contexts
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
        public virtual DbSet<ClassesHabilidade> ClassesHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagens { get; set; }
        public virtual DbSet<TiposHabilidade> TiposHabilidades { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__CLASSES__60FFF8011786FDE1");

                entity.ToTable("CLASSES");

                entity.HasIndex(e => e.NomeClasse, "UQ__CLASSES__F1ED810232AB25C7")
                    .IsUnique();

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("nomeClasse");
            });

            modelBuilder.Entity<ClassesHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdClasseHab)
                    .HasName("PK__CLASSES___77E64E4A5A81F80E");

                entity.ToTable("CLASSES_HABILIDADE");

                entity.Property(e => e.IdClasseHab).HasColumnName("idClasseHab");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.ClassesHabilidades)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__CLASSES_H__idCla__46E78A0C");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.ClassesHabilidades)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__CLASSES_H__idHab__47DBAE45");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__HABILIDA__655F7528ED483A37");

                entity.ToTable("HABILIDADES");

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
                    .HasConstraintName("FK__HABILIDAD__idTip__440B1D61");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__PERSONAG__E175C72E148E2A39");

                entity.ToTable("PERSONAGENS");

                entity.HasIndex(e => e.NomePersonagem, "UQ__PERSONAG__2075C7B8FB2F6257")
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
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__PERSONAGE__idCla__3E52440B");
            });

            modelBuilder.Entity<TiposHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHab)
                    .HasName("PK__TIPOS_HA__FD3EC2548062FF8C");

                entity.ToTable("TIPOS_HABILIDADE");

                entity.HasIndex(e => e.NomeTipoHab, "UQ__TIPOS_HA__98422FA32DD36246")
                    .IsUnique();

                entity.Property(e => e.IdTipoHab).HasColumnName("idTipoHab");

                entity.Property(e => e.NomeTipoHab)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoHab");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUser)
                    .HasName("PK__TIPOS_US__39DB342F51A79DE1");

                entity.ToTable("TIPOS_USUARIO");

                entity.HasIndex(e => e.Titulo, "UQ__TIPOS_US__38FA640F2ECD1E8B")
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
                    .HasName("PK__USUARIOS__645723A68363D63C");

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email, "UQ__USUARIOS__AB6E61643C056387")
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
                    .HasConstraintName("FK__USUARIOS__idTipo__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
