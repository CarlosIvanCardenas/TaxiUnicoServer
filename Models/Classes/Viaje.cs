using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiUnicoServer.Models.Classes
{
    public class Viaje
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Origen { get; set; }

        [Required]
        public string Destino { get; set; }

        public decimal Kilometros { get; set; }

        [Required]
        public DateTime HoraSolicitud { get; set; }

        [Required]
        public DateTime HoraPartida { get; set; }

        [Required]
        public DateTime HoraLlegada { get; set; }

        [Required]
        public Guid VehiculoId { get; set; }

        [Required, ForeignKey("VehiculoId")]
        public Vehiculo Vehiculo { get; set; }

        [Required]
        public Guid ClienteId { get; set; }

        [Required, ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Required]
        public int NumeroPasajeros { get; set; }

        [Required]
        public string FormaPago { get; set; }
    }
}