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

        [HttpGet("{id}", Name = "GetClienteById")]
        public ActionResult<Cliente> GetById(Guid id)
        {
            var item = _context.Clientes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("email/{email}")]
        public ActionResult<Cliente> GetByEmail(string email)
        {
            var item = _context.Clientes.SingleOrDefault(x => x.Correo == email);
            Console.WriteLine($"Entro: {item}");
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente item)
        {
            _context.Clientes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetClienteById", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Cliente item)
        {
            var client = _context.Clientes.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            client.Correo = item.Correo;
            client.Contraseña =  item.Contraseña;
            client.PrimerNombre = item.PrimerNombre;
            client.Apellidos = item.Apellidos;
            client.Telefono = item.Telefono;
            client.Direccion = item.Direccion;
            client.Estatus = item.Estatus;

            _context.Clientes.Update(client);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("login/{email}/{password}", Name = "ClienteLogin")]
        public ActionResult<Cliente> Login(string email, string password)
        {
            var item = _context.Clientes.SingleOrDefault(x => x.Correo == email && x.Contraseña == password);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
