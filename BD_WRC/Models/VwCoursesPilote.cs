using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Keyless]
public partial class VwCoursesPilote
{
    [StringLength(50)]
    public string NomPilote { get; set; } = null!;

    [StringLength(50)]
    public string Prenom { get; set; } = null!;

    [StringLength(50)]
    public string Marque { get; set; } = null!;

    [StringLength(50)]
    public string Modele { get; set; } = null!;

    [StringLength(50)]
    public string Equipe { get; set; } = null!;

    [StringLength(50)]
    public string Temps { get; set; } = null!;

    [StringLength(100)]
    public string NomRallye { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? DateDebut { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? DateFin { get; set; }
}
