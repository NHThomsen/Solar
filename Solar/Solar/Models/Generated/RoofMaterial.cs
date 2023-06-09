﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("RoofMaterial")]
public partial class RoofMaterial
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Material { get; set; }

    [Column("RoofTypeID")]
    public int? RoofTypeId { get; set; }

    [InverseProperty("RoofMaterial")]
    public virtual ICollection<Assembly> Assemblies { get; set; } = new List<Assembly>();

    [ForeignKey("RoofTypeId")]
    [InverseProperty("RoofMaterials")]
    public virtual RoofType RoofType { get; set; }
}