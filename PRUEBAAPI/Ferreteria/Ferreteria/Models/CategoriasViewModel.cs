namespace Ferreteria.Models
{
    public class CategoriasViewModel
    {
        public int Cate_Id { get; set; }

        public string Cate_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Cate_Estado { get; set; }
    }
}
