﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("DimensioningConsumption")]
public partial class DimensioningConsumption
{
    [Key]
    [Column("ProjectID")]
    public int ProjectId { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column(TypeName = "decimal(19, 5)")]
    public decimal CurrentConsumption { get; set; }

    public bool HeatPump { get; set; }

    public bool HeatPumpIncluded { get; set; }

    [Column(TypeName = "decimal(6, 5)")]
    public decimal? HouseSize { get; set; }

    public bool ElectricVehicle { get; set; }

    [Column("EVIncluded")]
    public bool Evincluded { get; set; }

    public int EvKilometer { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("DimensioningConsumptions")]
    public virtual ConsumptionCategory Category { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("DimensioningConsumption")]
    public virtual Project Project { get; set; }
}