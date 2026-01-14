using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.domain.clases;

[Table("citas", Schema = "vmoran")]
public partial class Cita
{
    [Key]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("id_empleado")]
    public int IdEmpleado { get; set; }

    [Column("fecha")]
    public DateOnly Fecha { get; set; }

    [Column("hora")]
    public TimeOnly Hora { get; set; }

    [Column("estado")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [InverseProperty("IdCitaNavigation")]
    public virtual ICollection<DetalleCita> DetalleCita { get; set; } = new List<DetalleCita>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Cita")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdEmpleado")]
    [InverseProperty("Cita")]
    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    [InverseProperty("IdCitaNavigation")]
    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
