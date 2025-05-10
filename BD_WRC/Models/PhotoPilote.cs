using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("PhotoPilote", Schema = "Equipes")]
[Index("Identifiant", Name = "UC_PhotoPilote_Identifiant", IsUnique = true)]
public partial class PhotoPilote
{
    [Key]
    [Column("PhotoPiloteID")]
    public int PhotoPiloteId { get; set; }

    public Guid Identifiant { get; set; }

    [Column("PiloteID")]
    public int? PiloteId { get; set; }

    public byte[]? PilotePhotoContent { get; set; }

    [ForeignKey("PiloteId")]
    [InverseProperty("PhotoPilotes")]
    public virtual Pilote? Pilote { get; set; }
}
