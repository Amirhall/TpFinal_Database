using System;
using System.Collections.Generic;
using BD_WRC.Models;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Data;

public partial class BD_WRCContext : DbContext
{
    public BD_WRCContext()
    {
    }

    public BD_WRCContext(DbContextOptions<BD_WRCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<Classement> Classements { get; set; }

    public virtual DbSet<DetailRallye> DetailRallyes { get; set; }

    public virtual DbSet<Equipe> Equipes { get; set; }

    public virtual DbSet<PhotoPilote> PhotoPilotes { get; set; }

    public virtual DbSet<Pilote> Pilotes { get; set; }

    public virtual DbSet<Rallye> Rallyes { get; set; }

    public virtual DbSet<Trophee> Trophees { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Voiture> Voitures { get; set; }

    public virtual DbSet<VwCoursesPilote> VwCoursesPilotes { get; set; }

    public virtual DbSet<VwPilotesStatistiquesAvancee> VwPilotesStatistiquesAvancees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BD_WRC");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__changelo__3213E83F0D3E8D39");

            entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Classement>(entity =>
        {
            entity.HasKey(e => e.ClassementId).HasName("PK_Classement_ClassementID");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Classements).HasConstraintName("FK_Classement_EquipeID");

            entity.HasOne(d => d.Pilote).WithMany(p => p.Classements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Classement_PiloteID");

            entity.HasOne(d => d.Rallye).WithMany(p => p.Classements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Classement_RallyeID");

            entity.HasOne(d => d.Voiture).WithMany(p => p.Classements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Classement_VoitureID");
        });

        modelBuilder.Entity<DetailRallye>(entity =>
        {
            entity.HasKey(e => e.DetailRallyeId).HasName("PK_DetailRallye_DetailRallyeID");

            entity.HasOne(d => d.Equipe).WithMany(p => p.DetailRallyes).HasConstraintName("FK_DetailRallye_EquipeID");

            entity.HasOne(d => d.Rallye).WithMany(p => p.DetailRallyes).HasConstraintName("FK_DetailRallye_RallyeID");
        });

        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.EquipeId).HasName("PK_Equipe_EquipeID");

            entity.HasOne(d => d.Voiture).WithMany(p => p.Equipes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Equipe_VoitureID");
        });

        modelBuilder.Entity<PhotoPilote>(entity =>
        {
            entity.HasKey(e => e.PhotoPiloteId).HasName("PK_PhotoPilote_PhotoPiloteID");

            entity.Property(e => e.Identifiant).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Pilote).WithMany(p => p.PhotoPilotes).HasConstraintName("FK_PhotoPilote_PiloteID");
        });

        modelBuilder.Entity<Pilote>(entity =>
        {
            entity.HasKey(e => e.PiloteId).HasName("PK_Pilote_PiloteID");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Pilotes).HasConstraintName("FK_Pilote_EquipeID");
        });

        modelBuilder.Entity<Rallye>(entity =>
        {
            entity.HasKey(e => e.RallyeId).HasName("PK_Rallye_RallyeID");
        });

        modelBuilder.Entity<Trophee>(entity =>
        {
            entity.HasKey(e => e.TropheeId).HasName("PK_Trophee_TropheeID");

            entity.HasOne(d => d.Pilote).WithMany(p => p.Trophees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trophee_PiloteID");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.UtilisateurId).HasName("PK_Utilisateur_UtilisateurID");
        });

        modelBuilder.Entity<Voiture>(entity =>
        {
            entity.HasKey(e => e.VoitureId).HasName("PK_Voiture_VoitureID");
        });

        modelBuilder.Entity<VwCoursesPilote>(entity =>
        {
            entity.ToView("VwCoursesPilote", "Rallyes");
        });

        modelBuilder.Entity<VwPilotesStatistiquesAvancee>(entity =>
        {
            entity.ToView("vw_PilotesStatistiquesAvancees", "Rallyes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
