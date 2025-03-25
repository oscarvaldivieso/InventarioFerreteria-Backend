namespace Ferreteria.Models
{
    public class RolDetallesViewModel
    {
        public int Role_Id { get; set; }
        public string Role_Descripcion { get; set; }
        public DateTime Feca_Creacion { get; set; }
        public DateTime Feca_Modificacion { get; set; }
        public string Usua_Creacion { get; set; }
        public string Usua_Modificacion { get; set; }
        public string UsuaC_Nombre { get; set; }
        public string UsuaM_Nombre { get; set; }
        public string PantIds { get; set; }
        public string PantNombres { get; set; }
    }
}
