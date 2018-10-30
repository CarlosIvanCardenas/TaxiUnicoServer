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
    }
}