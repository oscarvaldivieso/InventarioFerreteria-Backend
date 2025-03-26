using FerreteriaEntities.Entities;

namespace Ferreteria.Models
{
    public class CompraViewModel
    {
        public int Comp_Id { get; set; }

        public int Prov_Id { get; set; }

        public DateOnly Comp_Fecha { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Comp_Estado { get; set; }
    }
}