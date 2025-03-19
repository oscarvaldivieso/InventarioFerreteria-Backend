﻿using System.ComponentModel.DataAnnotations;

namespace Ferreteria.Models
{
    public class ClientesViewModel
    {
        [Display(Name = "Id")]
        public int Clie_Id { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Clie_DNI { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Clie_Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Clie_Apellido { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Clie_Sexo { get; set; }

        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int EsCv_Id { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Muni_Codigo { get; set; }

        [Display(Name = "Dirección Exacta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Clie_Direccion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Feca_Creacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Feca_Modificacion { get; set; }

        public bool? Clie_Estado { get; set; }
    }
}