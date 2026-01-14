using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.service.vm.domain.clases;

[Table("servicios", Schema = "vmoran")]
public partial class Servicio
{
    [Key]
    [Column("id_servicio")]
    public int IdServicio { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("duracion_minutos")]
    public int DuracionMinutos { get; set; }

    [Column("precio")]
    [Precision(10, 2)]
    public decimal Precio { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

    [Column("creado_en", TypeName = "timestamp without time zone")]
    public DateTime? CreadoEn { get; set; }

    [Column("actualizado_en", TypeName = "timestamp without time zone")]
    public DateTime? ActualizadoEn { get; set; }

    [InverseProperty("IdServicioNavigation")]
    public virtual ICollection<DetalleCita> DetalleCita { get; set; } = new List<DetalleCita>();
}
