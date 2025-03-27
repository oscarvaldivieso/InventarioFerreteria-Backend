using FerreteriaEntities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ferreteria.Models
{
    public class CompraViewModel
    {
        public int Comp_Id { get; set; }

        public int Prov_Id { get; set; }

        public DateTime Comp_Fecha { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Comp_Estado { get; set; }

        [NotMapped]
        public DateOnly? Fecha_Inicio { get; set; }

        [NotMapped]
        public DateOnly? Fecha_Fin { get; set; }
    }
}