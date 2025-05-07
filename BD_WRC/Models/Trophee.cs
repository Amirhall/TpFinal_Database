using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("Trophee", Schema = "Equipes")]
public partial class Trophee
{
    [Key]
    [Column("TropheeID")]
    public int TropheeId { get; set; }

    [StringLength(100)]
    public string NomTrophee { get; set; } = null!;

    [Column("PiloteID")]
    public int PiloteId { get; set; }

    [ForeignKey("PiloteId")]
    [InverseProperty("Trophees")]
    public virtual Pilote Pilote { get; set; } = null!;
}
