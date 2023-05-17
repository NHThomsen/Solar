﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solar;

[Table("Installer")]
public partial class Installer
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [Column("Installer")]
    [StringLength(255)]
    [Unicode(false)]
    public string Installer1 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string AccountNumber { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Department { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Contact { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string PhoneNumber { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Installer")]
    public virtual User User { get; set; }
}