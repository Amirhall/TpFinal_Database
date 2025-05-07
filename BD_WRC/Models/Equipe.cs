using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("Equipe", Schema = "Equipes")]
public partial class Equipe
{
    [Key]
    [Column("EquipeID")]
    public int EquipeId { get; set; }

    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [StringLength(50)]
    public string? Constructeur { get; set; }

    [Column("VoitureID")]
    public int VoitureId { get; set; }

    [InverseProperty("Equipe")]
    public virtual ICollection<Classement> Classements { get; set; } = new List<Classement>();

    [InverseProperty("Equipe")]
    public virtual ICollection<DetailRallye> DetailRallyes { get; set; } = new List<DetailRallye>();

    [InverseProperty("Equipe")]
    public virtual ICollection<Pilote> Pilotes { get; set; } = new List<Pilote>();

    [ForeignKey("VoitureId")]
    [InverseProperty("Equipes")]
    public virtual Voiture Voiture { get; set; } = null!;
}
