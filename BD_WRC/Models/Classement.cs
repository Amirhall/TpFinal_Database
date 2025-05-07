using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("Classement", Schema = "Rallyes")]
public partial class Classement
{
    [Key]
    [Column("ClassementID")]
    public int ClassementId { get; set; }

    public int Position { get; set; }

    [StringLength(50)]
    public string Temps { get; set; } = null!;

    [Column("EquipeID")]
    public int? EquipeId { get; set; }

    [Column("VoitureID")]
    public int VoitureId { get; set; }

    [Column("PiloteID")]
    public int PiloteId { get; set; }

    [Column("RallyeID")]
    public int RallyeId { get; set; }

    [ForeignKey("EquipeId")]
    [InverseProperty("Classements")]
    public virtual Equipe? Equipe { get; set; }

    [ForeignKey("PiloteId")]
    [InverseProperty("Classements")]
    public virtual Pilote Pilote { get; set; } = null!;

    [ForeignKey("RallyeId")]
    [InverseProperty("Classements")]
    public virtual Rallye Rallye { get; set; } = null!;

    [ForeignKey("VoitureId")]
    [InverseProperty("Classements")]
    public virtual Voiture Voiture { get; set; } = null!;
}
