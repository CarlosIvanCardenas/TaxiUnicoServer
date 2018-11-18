using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiUnicoServer.Models;
using TaxiUnicoServer.Models.Classes;

namespace TaxiUnicoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private DataContext _context;

        public ViajesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Viaje>> GetAll()
        {
            return _context.Viajes.ToList();
        }

        [HttpGet("{id}", Name = "GetViajeById")]
        public ActionResult<Viaje> GetById(Guid id)
        {
            var item = _context.Viajes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("vehiculo/{vehiculo}", Name = "GetViajeByVehiculo")]
        public ActionResult<List<Viaje>> GetByVehiculo(Guid vehiculo)
        {
            return _context.Viajes
                        .Where(x => x.VehiculoId == vehiculo)
                        .ToList();
        }

        [HttpGet("taxista/{taxista}", Name = "GetViajeByTaxista")]
        public ActionResult<List<Viaje>> GetByTaxista(Guid taxista)
        {
            var vehiculos = _context.Vehiculos.Where(x => x.TaxistaId == taxista).Include(x => x.Taxista).ToArray();
            List<Viaje> viajes = new List<Viaje>();
            foreach (var v in vehiculos)
            {
                viajes.AddRange(_context.Viajes.Where(x => x.VehiculoId == v.Id).Include(x => x.Cliente).ToList());
            }
            return viajes;
        }

        [HttpGet("cliente/{cliente}", Name = "GetViajeByCliente")]
        public ActionResult<List<Viaje>> GetByCliente(Guid cliente)
        {
            return _context.Viajes
                        .Where(x => x.ClienteId == cliente)
                        .Include(x => x.Cliente)
                        .Include(x => x.Vehiculo)
                            .ThenInclude(x => x.Taxista)
                        .ToList();
        }

        [HttpGet("cliente/{cliente}/{fecha}", Name = "GetViajeByClienteFecha")]
        public ActionResult<List<Viaje>> GetByClienteFecha(Guid cliente, DateTime fecha)
        {
            return _context.Viajes
                        .Where(x => x.ClienteId == cliente && x.HoraPartida == fecha)
                        .Include(x => x.Cliente)
                        .Include(x => x.Vehiculo)
                            .ThenInclude(x => x.Taxista)
                        .ToList();
        }

        [HttpGet("cliente/{cliente}/{fechaP}/{fechaL}", Name = "GetViajeByClienteRangoFechas")]
        public ActionResult<List<Viaje>> GetByClienteRangoFechas(Guid cliente, DateTime fechaP, DateTime fechaL)
        {
            return _context.Viajes
                    .Where(x => x.ClienteId == cliente && x.HoraPartida > fechaP && x.HoraPartida < fechaL)
                    .Include(x => x.Cliente)
                        .Include(x => x.Vehiculo)
                            .ThenInclude(x => x.Taxista)
                    .ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Viaje item)
        {
            _context.Viajes.Add(item);
            _context.SaveChanges();
            
            return CreatedAtRoute("GetViajeById", new { id = item.Id }, item);
        }

        [HttpGet("pendientes")]
        public ActionResult<List<Viaje>> GetPendientes()
        {
            var pendientes = _context.Viajes.Where(x => x.Estatus == "Pendiente").ToList();
            return pendientes;
        }

        [HttpPut("pendientes/{id}")]
        public IActionResult Update(Guid id, Viaje item)
        {
            var viaje = _context.Viajes.Find(id);
            if (viaje == null)
            {
                return NotFound();
            }

            viaje.VehiculoId = item.VehiculoId; 

            _context.Viajes.Update(viaje);
            _context.SaveChanges();
            return NoContent();
        }
    }
}