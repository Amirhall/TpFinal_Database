using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("DetailRallye", Schema = "Rallyes")]
public partial class DetailRallye
{
    [Key]
    [Column("DetailRallyeID")]
    public int DetailRallyeId { get; set; }

    [Column("RallyeID")]
    public int? RallyeId { get; set; }

    [Column("EquipeID")]
    public int? EquipeId { get; set; }

    [ForeignKey("EquipeId")]
    [InverseProperty("DetailRallyes")]
    public virtual Equipe? Equipe { get; set; }

    [ForeignKey("RallyeId")]
    [InverseProperty("DetailRallyes")]
    public virtual Rallye? Rallye { get; set; }
}
