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
    public class AdminsController : ControllerBase
    {
        private DataContext _context;
        public AdminsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Administrador>> GetAll()
        {
            return _context.Administradores.ToList();
        }

        [HttpGet("{id}", Name = "GetAdminById")]
        public ActionResult<Administrador> GetById(Guid id)
        {
            var item = _context.Administradores.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("email/{email}", Name = "GetAdminByEmail")]
        public ActionResult<Administrador> GetByEmail(string email)
        {
            var item = _context.Administradores.SingleOrDefault(x => x.Correo == email);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Administrador item)
        {
            _context.Administradores.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAdminById", new { id = item.Id }, item);
        }
    }
}