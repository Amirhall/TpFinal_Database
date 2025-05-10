using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("Pilote", Schema = "Equipes")]
public partial class Pilote
{
    [Key]
    [Column("PiloteID")]
    public int PiloteId { get; set; }

    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [StringLength(50)]
    public string Prenom { get; set; } = null!;

    public DateOnly DateNaissance { get; set; }

    [StringLength(50)]
    public string? Nationalite { get; set; }

    [Column("EquipeID")]
    public int? EquipeId { get; set; }

    [InverseProperty("Pilote")]
    public virtual ICollection<Classement> Classements { get; set; } = new List<Classement>();

    [ForeignKey("EquipeId")]
    [InverseProperty("Pilotes")]
    public virtual Equipe? Equipe { get; set; }

    [InverseProperty("Pilote")]
    public virtual ICollection<PhotoPilote> PhotoPilotes { get; set; } = new List<PhotoPilote>();

    [InverseProperty("Pilote")]
    public virtual ICollection<Trophee> Trophees { get; set; } = new List<Trophee>();
}
