using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Entities.Entities
{
    public class RolDetalles
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
