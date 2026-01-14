using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.domain.clases;

[Table("detalle_cita", Schema = "vmoran")]
public partial class DetalleCita
{
    [Key]
    [Column("id_detalle")]
    public int IdDetalle { get; set; }

    [Column("id_cita")]
    public int IdCita { get; set; }

    [Column("id_servicio")]
    public int IdServicio { get; set; }

    [Column("precio_aplicado")]
    [Precision(10, 2)]
    public decimal PrecioAplicado { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [ForeignKey("IdCita")]
    [InverseProperty("DetalleCita")]
    public virtual Cita IdCitaNavigation { get; set; } = null!;

    [ForeignKey("IdServicio")]
    [InverseProperty("DetalleCita")]
    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
