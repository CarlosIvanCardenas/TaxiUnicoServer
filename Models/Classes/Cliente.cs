using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiUnicoServer.Models.Classes
{
    public class Cliente
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required, DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

	    public string Estatus { get; set; }

        [Column(TypeName = "decimal(2, 1)")]
        public decimal Puntuacion { get; set; }
    }
}
