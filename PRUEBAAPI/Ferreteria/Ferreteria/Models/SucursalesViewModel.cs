namespace Ferreteria.Models
{
    public class SucursalesViewModel
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
    }
}
