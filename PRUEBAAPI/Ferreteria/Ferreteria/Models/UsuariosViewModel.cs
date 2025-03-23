using FerreteriaEntities.Entities;

namespace Ferreteria.Models
{
    public class UsuariosViewModel
    {
        public int Usua_Id { get; set; }

        public string Usua_Nombre { get; set; }

        public string Usua_Clave { get; set; }

        public int Empl_Id { get; set; }

        public int Role_Id { get; set; }

        public bool? Usua_EsAdmin { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Usua_Estado { get; set; }

        public virtual tbEmpleados Empl { get; set; }

        public virtual tbRoles Role { get; set; }
    }
}
