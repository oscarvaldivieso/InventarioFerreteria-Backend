using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Entities.Entities
{
    public class UsuarioLoginResponse
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre_Empleado { get; set; }
        public int Rol { get; set; }
        public int Empleado_Id { get; set; }
        public bool EsAdmin { get; set; }
        
    }
}
