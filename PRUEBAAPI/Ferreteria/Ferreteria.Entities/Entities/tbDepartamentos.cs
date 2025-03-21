﻿#nullable disable
using System;
using System.Collections.Generic;

namespace FerreteriaEntities.Entities;

public partial class tbDepartamentos
{
    public string Depa_Codigo { get; set; }

    public string Depa_Descripcion { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Feca_Creacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Feca_Modificacion { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbMunicipios> tbMunicipios { get; set; } = new List<tbMunicipios>();
}