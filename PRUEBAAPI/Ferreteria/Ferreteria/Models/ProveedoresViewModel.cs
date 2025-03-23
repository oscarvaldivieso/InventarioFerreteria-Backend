namespace Ferreteria.Models
{
    public class ProveedoresViewModel
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
    }
}
