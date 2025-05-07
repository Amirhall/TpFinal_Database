using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BD_WRC.Models;

[Table("Utilisateur", Schema = "Utilisateurs")]
[Index("Courriel", Name = "UC_Utilisateur_Courriel", IsUnique = true)]
public partial class Utilisateur
{
    [Key]
    [Column("UtilisateurID")]
    public int UtilisateurId { get; set; }

    [StringLength(256)]
    public string Courriel { get; set; } = null!;

    [MaxLength(32)]
    public byte[] MotDePasseHache { get; set; } = null!;

    [MaxLength(16)]
    public byte[] MdpSel { get; set; } = null!;
}
