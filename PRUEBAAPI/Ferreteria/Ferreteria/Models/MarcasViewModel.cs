namespace Ferreteria.Models
{
    public class MarcasViewModel
    {
        public int Marc_Id { get; set; }

        public string Marc_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Marc_Estado { get; set; }
    }
}
