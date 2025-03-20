#nullable disable

using System;
using System.Collections.Generic;

namespace FerreteriaEntities.Entities;

public partial class tbEstadosCiviles
{
    public int EsCv_Id { get; set; }

    public string EsCv_Descripcion { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Feca_Creacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Feca_Modificacion { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbClientes> tbClientes { get; set; } = new List<tbClientes>();

    public virtual ICollection<tbEmpleados> tbEmpleados { get; set; } = new List<tbEmpleados>();
}