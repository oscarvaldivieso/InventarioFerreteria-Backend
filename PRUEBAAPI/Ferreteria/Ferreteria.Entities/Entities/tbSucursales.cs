﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FerreteriaEntities.Entities;

public partial class tbSucursales
{
    public int Sucu_Id { get; set; }

    public string Sucu_Nombre { get; set; }

    public string Muni_Codigo { get; set; }

    public string Sucu_DireccionExacta { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime? Feca_Creacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Feca_Modificacion { get; set; }

    public bool? Sucu_Estado { get; set; }

    public virtual tbMunicipios Muni_CodigoNavigation { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }
}