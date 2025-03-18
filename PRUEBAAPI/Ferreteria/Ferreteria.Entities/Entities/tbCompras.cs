﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FerreteriaEntities.Entities;

public partial class tbCompras
{
    public int Comp_Id { get; set; }

    public int Prov_Id { get; set; }

    public DateOnly Comp_Fecha { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Feca_Creacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Feca_Modificacion { get; set; }

    public bool? Comp_Estado { get; set; }

    public virtual tbProveedores Prov { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbComprasDetalles> tbComprasDetalles { get; set; } = new List<tbComprasDetalles>();
}