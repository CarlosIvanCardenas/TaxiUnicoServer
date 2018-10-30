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
            return _context.Viajes.Where(x => x.VehiculoId == vehiculo).ToList();
        }

        [HttpGet("cliente/{cliente}", Name = "GetViajeByCliente")]
        public ActionResult<List<Viaje>> GetByCliente(Guid cliente)
        {
            return _context.Viajes.Where(x => x.ClienteId == cliente).ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Viaje item)
        {
            _context.Viajes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetViajeById", new { id = item.Id }, item);
        }
    }
}