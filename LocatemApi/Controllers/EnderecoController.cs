using Microsoft.EntityFrameworkCore;
using LocatemApi.Model;
using LocatemApi.Data;
using Microsoft.AspNetCore.Mvc;
using LocatemApi.DTO;
using LocatemApi.Enum;

namespace LocatemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly AppDbContext _enderecoDbContext;
        public EnderecoController(AppDbContext context)
        {
            _enderecoDbContext = context;
        }
        [HttpGet("GetAllEnderecos")]
        public async Task<IActionResult> GetAllEnderecos()
        {
            List<Endereco> listaEnderecos = await _enderecoDbContext.Enderecos.ToListAsync();
            return Ok(listaEnderecos);
        }

        [HttpPost("CriarEndereco")]
        public async Task<IActionResult> CriarEndereco([FromBody] CriarEnderecoDTO dadosEndereco)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cliente? clienteEncontrado = await _enderecoDbContext.Cliente.
                 FirstOrDefaultAsync(cliente => cliente.Id == dadosEndereco.ClienteId);
            if (clienteEncontrado == null)
            {
                return NotFound($"Cliente com ID {dadosEndereco.ClienteId} não encontrado.");
            }
            Endereco novoEndereco = new Endereco
            {
                Logradouro = dadosEndereco.Logradouro,
                Numero = dadosEndereco.Numero,
                Complemento = dadosEndereco.Complemento,
                Bairro = dadosEndereco.Bairro,
                Cidade = dadosEndereco.Cidade,
                Estado = dadosEndereco.Estado,
                CEP = dadosEndereco.Cep,
                TipoEndereco = dadosEndereco.TipoEndereco,
                ClienteId = dadosEndereco.ClienteId
            };
            _enderecoDbContext.Enderecos.Add(novoEndereco);
            int resultadoInsercao = await _enderecoDbContext.SaveChangesAsync();
            if (resultadoInsercao > 0)
            {
                return Created();
            }
            return BadRequest("Endereço não foi registrado! ");

        }
    }
}
