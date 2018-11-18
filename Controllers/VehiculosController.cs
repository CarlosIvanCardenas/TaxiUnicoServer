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
    public class VehiculosController : ControllerBase
    {
        private DataContext _context;
        public VehiculosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Vehiculo>> GetAll()
        {
            return _context.Vehiculos.ToList();
        }

        [HttpGet("{id}", Name = "GetVehiculoById")]
        public ActionResult<Vehiculo> GetById(Guid id)
        {
            var item = _context.Vehiculos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("placa/{placa}", Name = "GetVehiculoByPlaca")]
        public ActionResult<Vehiculo> GetByPlaca(string placa)
        {
            var item = _context.Vehiculos.SingleOrDefault(x => x.Placa == placa);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("taxista/{taxista}", Name = "GetVehiculoByTaxista")]
        public ActionResult<List<Vehiculo>> GetByNumber(Guid taxista)
        {
            return _context.Vehiculos.Where(x => x.TaxistaId == taxista).ToList();
        }

        [HttpGet("taxista/actual/{taxista}")]
        public ActionResult<Vehiculo> GetActual(Guid taxista)
        {
            return _context.Vehiculos.Where(x => x.TaxistaId == taxista && x.Estatus == "Actual").FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Vehiculo item)
        {
            _context.Vehiculos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetVehiculoById", new { id = item.Id }, item);
        }
    }
}