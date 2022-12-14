//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAPA_DATOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public partial class ClIENTES
    {
        public int Id_Cliente { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Por favor ingrese un nombre valido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingrese solo números")]
      
        public string Numero_Identificacion { get; set; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Por favor ingrese la dirección de correo exacta")]

        public string Correo { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingrese solo números")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "*")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "*")]
        public string Direccion_Instalacion { get; set; }
        [Required(ErrorMessage = "*")]
        public int Id_Tipo_Identificacion { get; set; }
        [Required(ErrorMessage = "*")]
        public bool estado { get; set; }

        public virtual TIPO_IDENTIFICACION TIPO_IDENTIFICACION { get; set; }
    }
}
