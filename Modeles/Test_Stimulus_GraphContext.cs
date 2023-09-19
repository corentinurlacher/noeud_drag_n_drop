using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Capsule_Charles_Marc_Antoine.Modeles
{
    public partial class Test_Stimulus_GraphContext : DbContext
    {
        public Test_Stimulus_GraphContext()
        {
        }

        public Test_Stimulus_GraphContext(DbContextOptions<Test_Stimulus_GraphContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Graphe> Graphes { get; set; } = null!;
        public virtual DbSet<LiaisonEnfant> LiaisonEnfants { get; set; } = null!;
        public virtual DbSet<Noeud> Noeuds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=dicjwin01; Initial Catalog=Test_Stimulus_Graph; Integrated Security=True; TrustServerCertificate=True; Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Graphe>(entity =>
            {
                entity.ToTable("Graphe");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom");

                entity.Property(e => e.Statut)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("statut");
            });

            modelBuilder.Entity<LiaisonEnfant>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Liaison_enfant");

                entity.Property(e => e.NoeudEnfant).HasColumnName("noeud_enfant");

                entity.Property(e => e.NoeudParent).HasColumnName("noeud_parent");

                entity.HasOne(d => d.NoeudEnfantNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NoeudEnfant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Liaison_e__noeud__2A4B4B5E");

                entity.HasOne(d => d.NoeudParentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NoeudParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Liaison_e__noeud__29572725");
            });

            modelBuilder.Entity<Noeud>(entity =>
            {
                entity.ToTable("Noeud");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Couleur)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("couleur");

                entity.Property(e => e.GraphId).HasColumnName("graph_id");

                entity.Property(e => e.LiaisonParent).HasColumnName("liaison_parent");

                entity.Property(e => e.Nom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nom");

                entity.Property(e => e.Posx).HasColumnName("posx");

                entity.Property(e => e.Posy).HasColumnName("posy");

                entity.Property(e => e.Rayon).HasColumnName("rayon");

                entity.HasOne(d => d.Graph)
                    .WithMany(p => p.Noeuds)
                    .HasForeignKey(d => d.GraphId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Noeud__graph_id__276EDEB3");

                entity.HasOne(d => d.LiaisonParentNavigation)
                    .WithMany(p => p.InverseLiaisonParentNavigation)
                    .HasForeignKey(d => d.LiaisonParent)
                    .HasConstraintName("FK__Noeud__liaison_p__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
