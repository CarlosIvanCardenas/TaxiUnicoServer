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
    public class TaxistasController : ControllerBase
    {
        private DataContext _context;

        public TaxistasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Taxista>> GetAll()
        {
            return _context.Taxistas.ToList();
        }

        [HttpGet("{id}", Name = "GetTaxistaById")]
        public ActionResult<Taxista> GetById(Guid id)
        {
            var item = _context.Taxistas.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Administrador = _context.Administradores.Find(item.AdministradorId);
            return item;
        }

        [HttpGet("email/{email}", Name = "GetTaxistaByEmail")]
        public ActionResult<Taxista> GetByEmail(string email)
        {
            var item = _context.Taxistas.SingleOrDefault(x => x.Correo == email);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Taxista item)
        {
            _context.Taxistas.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTaxistaById", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Taxista item)
        {
            var taxista = _context.Taxistas.Find(id);
            if (taxista == null)
            {
                return NotFound();
            }

            taxista.Correo = item.Correo;
            taxista.Contraseña =  item.Contraseña;
            taxista.PrimerNombre = item.PrimerNombre;
            taxista.Apellidos = item.Apellidos;
            taxista.Telefono = item.Telefono;
            taxista.Direccion = item.Direccion;
            taxista.FechaModificado = DateTime.Now;
            taxista.Estatus = item.Estatus;

            _context.Taxistas.Update(taxista);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("login/{email}/{password}", Name = "TaxistaLogin")]
        public ActionResult<Taxista> Login(string email, string password)
        {
            var item = _context.Taxistas.SingleOrDefault(x => x.Correo == email && x.Contraseña == password);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
