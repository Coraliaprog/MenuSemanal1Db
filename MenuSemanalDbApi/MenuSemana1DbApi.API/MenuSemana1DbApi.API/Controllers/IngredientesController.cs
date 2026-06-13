using MenuSemana1DbApi.API.Data;
using MenuSemana1DbApi.API.Models.Dtos;
using MenuSemana1DbApi.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MenuSemana1DbApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IngredientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ingrediente>> GetAll()
        {
            var ingredientes = _context.Ingredientes.ToList();

            return Ok(ingredientes);
        }

        [HttpGet("{id}")]
        public ActionResult<Ingrediente> GetById(int id)
        {
            var ingrediente = _context.Ingredientes.Find(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return Ok(ingrediente);
        }

        [HttpPost]
        public ActionResult<Ingrediente> Create(CreateIngredienteDto ingredienteDto)
        {
            if (string.IsNullOrWhiteSpace(ingredienteDto.Nombre))
            {
                return BadRequest("El nombre del ingrediente es obligatorio.");
            }

            var comidaExists = _context.Comidas.Any(c => c.Id == ingredienteDto.ComidaId);

            if (!comidaExists)
            {
                return BadRequest($"No existe una comida con Id = {ingredienteDto.ComidaId}.");
            }

            var ingrediente = new Ingrediente
            {
                Nombre = ingredienteDto.Nombre,
                Categoria = ingredienteDto.Categoria,
                Cantidad = ingredienteDto.Cantidad,
                ComidaId = ingredienteDto.ComidaId,
                IsActive = true
            };

            _context.Ingredientes.Add(ingrediente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = ingrediente.Id }, ingrediente);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateIngredienteDto ingredienteDto)
        {
            var ingrediente = _context.Ingredientes.Find(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            var comidaExists = _context.Comidas.Any(c => c.Id == ingredienteDto.ComidaId);

            if (!comidaExists)
            {
                return BadRequest($"No existe una comida con Id = {ingredienteDto.ComidaId}.");
            }

            ingrediente.Nombre = ingredienteDto.Nombre;
            ingrediente.Categoria = ingredienteDto.Categoria;
            ingrediente.Cantidad = ingredienteDto.Cantidad;
            ingrediente.ComidaId = ingredienteDto.ComidaId;
            ingrediente.IsActive = ingredienteDto.IsActive;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ingrediente = _context.Ingredientes.Find(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            _context.Ingredientes.Remove(ingrediente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}