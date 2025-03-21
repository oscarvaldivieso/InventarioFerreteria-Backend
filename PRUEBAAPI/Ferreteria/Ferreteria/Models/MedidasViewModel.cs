namespace Ferreteria.Models
{
    public class MedidasViewModel
    {
        public int Medi_Id { get; set; }

        public string Medi_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Medi_Estado { get; set; }
    }
}
