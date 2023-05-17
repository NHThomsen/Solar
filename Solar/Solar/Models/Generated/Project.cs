﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solar;

[Table("Project")]
public partial class Project
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string CaseName { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Address { get; set; }

    [Column("ZIP")]
    public int Zip { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Deadline { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Followup { get; set; }

    [Column(TypeName = "date")]
    public DateTime? StartDate { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Installer { get; set; }

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

    [StringLength(2550)]
    [Unicode(false)]
    public string Remarks { get; set; }

    [Column("StatusID")]
    public int? StatusId { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column("DimensioningID")]
    public int? DimensioningId { get; set; }

    [InverseProperty("Project")]
    public virtual Assembly Assembly { get; set; }

    [InverseProperty("Project")]
    public virtual Battery Battery { get; set; }

    [InverseProperty("Project")]
    public virtual BatteryRequest BatteryRequest { get; set; }

    [ForeignKey("DimensioningId")]
    [InverseProperty("Projects")]
    public virtual Dimensioning Dimensioning { get; set; }

    [InverseProperty("Project")]
    public virtual DimensioningConsumption DimensioningConsumption { get; set; }

    [InverseProperty("Project")]
    public virtual DimensioningkWp DimensioningkWp { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Projects")]
    public virtual Status Status { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Projects")]
    public virtual User User { get; set; }
}