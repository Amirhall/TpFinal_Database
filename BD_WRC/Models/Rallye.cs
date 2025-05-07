using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("Rallye", Schema = "Rallyes")]
public partial class Rallye
{
    [Key]
    [Column("RallyeID")]
    public int RallyeId { get; set; }

    [StringLength(100)]
    public string Nom { get; set; } = null!;

    public DateOnly DateDebut { get; set; }

    public DateOnly DateFin { get; set; }

    [StringLength(100)]
    public string Ville { get; set; } = null!;

    [StringLength(100)]
    public string Pays { get; set; } = null!;

    [StringLength(50)]
    public string Terrain { get; set; } = null!;

    [Column(TypeName = "decimal(8, 2)")]
    public decimal? Distance { get; set; }

    [InverseProperty("Rallye")]
    public virtual ICollection<Classement> Classements { get; set; } = new List<Classement>();

    [InverseProperty("Rallye")]
    public virtual ICollection<DetailRallye> DetailRallyes { get; set; } = new List<DetailRallye>();
}
