using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("Voiture", Schema = "Equipes")]
public partial class Voiture
{
    [Key]
    [Column("VoitureID")]
    public int VoitureId { get; set; }

    [StringLength(50)]
    public string Marque { get; set; } = null!;

    [StringLength(50)]
    public string Modele { get; set; } = null!;

    public int Annee { get; set; }

    [StringLength(20)]
    public string Traction { get; set; } = null!;

    [StringLength(50)]
    public string Moteur { get; set; } = null!;

    public int Poids { get; set; }

    [Column("Vitesse_maximal", TypeName = "decimal(8, 2)")]
    public decimal VitesseMaximal { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Acceleration { get; set; }

    [InverseProperty("Voiture")]
    public virtual ICollection<Classement> Classements { get; set; } = new List<Classement>();

    [InverseProperty("Voiture")]
    public virtual ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();
}
