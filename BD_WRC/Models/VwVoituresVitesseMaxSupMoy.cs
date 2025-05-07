using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Keyless]
public partial class VwVoituresVitesseMaxSupMoy
{
    [StringLength(50)]
    public string Marque { get; set; } = null!;

    [StringLength(50)]
    public string Modele { get; set; } = null!;

    public int Annee { get; set; }

    [Column("Vitesse maximale", TypeName = "decimal(8, 2)")]
    public decimal VitesseMaximale { get; set; }
}
