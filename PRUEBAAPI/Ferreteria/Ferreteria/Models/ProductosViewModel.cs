namespace Ferreteria.Models
{
    public class ProductosViewModel
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

        public string? Prod_URLImg { get; set; }

        public int Medi_Id { get; set; }
    }
}
