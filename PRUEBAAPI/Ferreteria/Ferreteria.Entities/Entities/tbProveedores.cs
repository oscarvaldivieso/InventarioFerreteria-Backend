﻿#nullable disable
using System;
using System.Collections.Generic;

namespace FerreteriaEntities.Entities;

public partial class tbProveedores
{
    public int Prov_Id { get; set; }

    public string Prov_Nombre { get; set; }

    public string Prov_Contacto { get; set; }

    public string Muni_Codigo { get; set; }

    public string Prov_DireccionExacta { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Feca_Creacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Feca_Modificacion { get; set; }

    public bool? Prov_Estado { get; set; }

    public virtual tbMunicipios Muni_CodigoNavigation { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbCompras> tbCompras { get; set; } = new List<tbCompras>();

    public virtual ICollection<tbProductos> tbProductos { get; set; } = new List<tbProductos>();
}