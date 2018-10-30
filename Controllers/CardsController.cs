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
    public class CardsController : ControllerBase
    {
        private DataContext _context;
        public CardsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<TarjetaCredito>> GetAll()
        {
            return _context.TarjetasCredito.ToList();
        }

        [HttpGet("{id}/{number}", Name = "GetCardById")]
        public ActionResult<TarjetaCredito> GetById(Guid id, string number)
        {
            var item = _context.TarjetasCredito.Find(id, number);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("cliente/{cliente}", Name = "GetCardByCliente")]
        public ActionResult<List<TarjetaCredito>> GetByNumber(Guid cliente)
        {
            return _context.TarjetasCredito.Where(x => x.ClienteId == cliente).ToList();
        }

        [HttpGet("number/{number}", Name = "GetCardByNumber")]
        public ActionResult<TarjetaCredito> GetByNumber(string number)
        {
            var item = _context.TarjetasCredito.SingleOrDefault(x => x.NumeroTarjeta == number);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TarjetaCredito item)
        {
            _context.TarjetasCredito.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCardById", new { id = item.ClienteId, number = item.NumeroTarjeta }, item);
        }
    }
}