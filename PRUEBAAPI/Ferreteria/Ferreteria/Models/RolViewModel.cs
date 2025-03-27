using System.ComponentModel.DataAnnotations.Schema;

namespace Ferreteria.Models
{
    public class RolViewModel
    {
        public int Role_Id { get; set; }

        public string Role_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Role_Estado { get; set; }

        public List<int> PantIds { get; set; }

        [NotMapped]
        public int? Pant_Id { get; set; }

        [NotMapped]
        public string Pant_Descripicion { get; set; }
    }
}
