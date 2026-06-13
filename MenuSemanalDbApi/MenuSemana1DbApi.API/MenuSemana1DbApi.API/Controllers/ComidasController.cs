using MenuSemana1DbApi.API.Data;
using MenuSemana1DbApi.API.Models.Dtos;
using MenuSemana1DbApi.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenuSemana1DbApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComidasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comida>> GetAll()
        {
            var comidas = _context.Comidas
                .Include(c => c.Ingredientes)
                .ToList();

            return Ok(comidas);
        }

        [HttpGet("{id}")]
        public ActionResult<Comida> GetById(int id)
        {
            var comida = _context.Comidas
                .Include(c => c.Ingredientes)
                .FirstOrDefault(c => c.Id == id);

            if (comida == null)
            {
                return NotFound();
            }

            return Ok(comida);
        }

        [HttpPost]
        public ActionResult<Comida> Create(CreateComidaDto comidaDto)
        {
            if (string.IsNullOrWhiteSpace(comidaDto.Nombre))
            {
                return BadRequest("El nombre de la comida es obligatorio.");
            }

            var comida = new Comida
            {
                Nombre = comidaDto.Nombre,
                Tipo = comidaDto.Tipo,
                DiaSemana = comidaDto.DiaSemana,
                IsActive = true
            };

            _context.Comidas.Add(comida);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = comida.Id }, comida);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateComidaDto comidaDto)
        {
            var comida = _context.Comidas.Find(id);

            if (comida == null)
            {
                return NotFound();
            }

            comida.Nombre = comidaDto.Nombre;
            comida.Tipo = comidaDto.Tipo;
            comida.DiaSemana = comidaDto.DiaSemana;
            comida.IsActive = comidaDto.IsActive;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comida = _context.Comidas.Find(id);

            if (comida == null)
            {
                return NotFound();
            }

            _context.Comidas.Remove(comida);
            _context.SaveChanges();

            return NoContent();
        }
    }
}