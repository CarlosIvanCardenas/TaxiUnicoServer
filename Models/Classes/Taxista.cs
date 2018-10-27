using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiUnicoServer.Models.Classes
{
    public class Taxista
    {
        [Key, Required]
        public Guid Id { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required, DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public decimal Puntuacion { get; set; }

        //RegistradoPor
        [Required]
        public Guid AdministradorId { get; set; }

        [Required, ForeignKey("AdministradorId")]
        public Administrador Administrador { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificado { get; set; }
    }
}