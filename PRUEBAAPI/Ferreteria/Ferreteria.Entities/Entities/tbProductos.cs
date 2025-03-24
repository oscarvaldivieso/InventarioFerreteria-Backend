#nullable disable
using System;
using System.Collections.Generic;

namespace FerreteriaEntities.Entities;

public partial class tbProductos
{
    public int Prod_Id { get; set; }

    public string Prod_Descripcion { get; set; }

    public int Marc_Id { get; set; }

    public int Cate_Id { get; set; }

    public int Prov_Id { get; set; }

    public string Prod_Modelo { get; set; }

    public int Prod_Cantidad { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Feca_Creacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Feca_Modificacion { get; set; }

    public bool? Prod_Estado { get; set; }

    public string Prod_URLImg { get; set; }

    public int Medi_Id { get; set; }

    public virtual tbCategorias Cate { get; set; }

    public virtual tbMarcas Marc { get; set; }

    public virtual tbMedidas Medi { get; set; }

    public virtual tbProveedores Prov { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbComprasDetalles> tbComprasDetalles { get; set; } = new List<tbComprasDetalles>();

    public virtual ICollection<tbVentasDetalles> tbVentasDetalles { get; set; } = new List<tbVentasDetalles>();
}