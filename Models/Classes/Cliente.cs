using System;
using System.ComponentModel.DataAnnotations;

namespace TaxiUnicoServer.Models.Classes
{
    public class Cliente
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
    }
}