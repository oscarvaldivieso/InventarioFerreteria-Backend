﻿#nullable disable
using System;
using System.Collections.Generic;

namespace FerreteriaEntities.Entities;

public partial class tbEmpleados
{
    public int Empl_Id { get; set; }

    public string Empl_DNI { get; set; }

    public string Empl_Nombre { get; set; }

    public string Empl_Apellido { get; set; }

    public string Empl_Sexo { get; set; }

    public int EsCv_Id { get; set; }

    public int Carg_Id { get; set; }

    public string Muni_Codigo { get; set; }

    public string Empl_Direccion { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Feca_Creacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Feca_Modificacion { get; set; }

    public bool? Empl_Estado { get; set; }

    public virtual tbCargos Carg { get; set; }

    public virtual tbEstadosCiviles EsCv { get; set; }

    public virtual tbMunicipios Muni_CodigoNavigation { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbUsuarios> tbUsuarios { get; set; } = new List<tbUsuarios>();
}