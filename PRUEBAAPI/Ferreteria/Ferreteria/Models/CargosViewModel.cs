namespace Ferreteria.Models
{
    public class CargosViewModel
    {
        public int Carg_Id { get; set; }

        public string Carg_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Carg_Estado { get; set; }
    }
}