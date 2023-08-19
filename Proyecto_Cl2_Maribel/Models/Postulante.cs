using System.ComponentModel.DataAnnotations;

namespace Proyecto_Cl2_Maribel.Models
{
    public class Postulante
    {

        [Display(Name = "ID")]
        public int idPostulante { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "DNI requerido!")]     
        [RegularExpression(@"[\d]{8}", ErrorMessage = "Digite 8 numeros")]      
        public string? dniPostulante { get; set; }
        
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Nombre(s) requerido(s)!")]
        [RegularExpression(@"^([a-zA-Z ]*?)\s+([a-zA-Z]*)$", ErrorMessage = "Digite solo letras")]
        public string? nombresPostulante { get; set; }
        
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Apellido(s) requerido(s)!")]
        [RegularExpression(@"^([a-zA-Z ]*?)\s+([a-zA-Z]*)$", ErrorMessage = "Digite solo letras")]
        public string? apellidosPostulante { get; set; }

        [Display(Name = "Colegio de Procedencia")]
        [RegularExpression(@"^([a-zA-Z ]*?)\s+([a-zA-Z]*)$", ErrorMessage = "Digite solo letras y puntos")]
        public string? nombreColegio { get; set; }

        [Display(Name = "Año de Egreso")]
        [Required(ErrorMessage = "Año requerido!")]
        [RegularExpression(@"[\d]{4}", ErrorMessage = "Digita 4 numeros")]
        public int anioEgreso { get; set; }


        [Required]
        [Display(Name = "ID Carrera")]
        public int idCarrera { get; set; }
        [Display(Name = "Carrera")]
        public string? nombreCarrera { get; set; }
    }
}
