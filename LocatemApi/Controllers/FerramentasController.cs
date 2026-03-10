using Microsoft.AspNetCore.Mvc;

namespace LocatemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FerramentasController : ControllerBase
    {
    // Miguel e Stephany
    
        // GET api/ferramentas/GetAll
        [HttpGet("GetAll")]
        public IActionResult GetAllFerramentas()
        {
            var ferramentas = new[]
            {
                new { Id = 1, Nome = "Furadeira", Marca = "Bosch", Disponivel = true },
                new { Id = 2, Nome = "Parafusadeira", Marca = "Makita", Disponivel = true },
                new { Id = 3, Nome = "Serra Circular", Marca = "DeWalt", Disponivel = false }
            };

            return Ok(ferramentas);
        }

        // GET api/ferramentas/GetById/1
        [HttpGet("GetById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var ferramentas = new[]
            {
                new { Id = 1, Nome = "Furadeira", Marca = "Bosch", Disponivel = true },
                new { Id = 2, Nome = "Parafusadeira", Marca = "Makita", Disponivel = true },
                new { Id = 3, Nome = "Serra Circular", Marca = "DeWalt", Disponivel = false },
                new { Id = 4, Nome = "Esmerilhadeira", Marca = "Black & Decker", Disponivel = true }
            };

            var ferramenta = ferramentas.FirstOrDefault(f => f.Id == id);

            if (ferramenta == null)
            {
                return BadRequest(
                    new
                    {
                        Erro = true,
                        Mensagem = $"A ferramenta com o id {id} não foi encontrada"
                    }
                );
            }

            return Ok(ferramenta);
        }
    }
}
