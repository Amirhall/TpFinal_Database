using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Keyless]
public partial class VwPilotesStatistiquesAvancee
{
    [Column("PiloteID")]
    public int PiloteId { get; set; }

    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [StringLength(50)]
    public string Prenom { get; set; } = null!;

    [StringLength(50)]
    public string? Nationalite { get; set; }

    public int? NombreParticipations { get; set; }

    public int? NombreVictoires { get; set; }

    public int? MeilleurePosition { get; set; }

    [Column(TypeName = "numeric(38, 6)")]
    public decimal? PositionMoyenne { get; set; }

    [StringLength(50)]
    public string NomEquipe { get; set; } = null!;
}
