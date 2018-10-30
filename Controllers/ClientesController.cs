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
    public class ClientesController : ControllerBase
    {
        private DataContext _context;
        public ClientesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetAll()
        {
            return _context.Clientes.ToList();
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Cliente> GetById(Guid id)
        {
            var item = _context.Clientes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("email/{email}", Name = "GetByEmail")]
        public ActionResult<Cliente> GetByEmail(string email)
        {
            var item = _context.Clientes.SingleOrDefault(x => x.Correo == email);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente item)
        {
            Console.WriteLine("ENTRO");
            _context.Clientes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetById", new { id = item.Id }, item);
        }
    }
}