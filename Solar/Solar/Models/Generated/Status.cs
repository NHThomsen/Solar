﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("Status")]
public partial class Status
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Status")]
    [StringLength(255)]
    [Unicode(false)]
    public string Status1 { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}