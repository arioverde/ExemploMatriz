using ApiCliente.Domain.Models;
using ApiCliente.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCliente.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClienteController()
        {
            _service = new ClienteService();
        }

        [HttpGet("cliente")]
        public IActionResult Listar()
        {
            return StatusCode(200, _service.Listar());
        }

        [HttpPost("cliente")]
        public IActionResult Inserir(Cliente model)
        {
            _service.Incluir(model);
            return StatusCode(201);
        }

        [HttpDelete("cliente")]
        public IActionResult Deletar(string cpfCliente)
        {
            _service.Deletar(cpfCliente);
            return StatusCode(200);
        }

        [HttpPut("cliente")]
        public IActionResult Atualizar(Cliente model)
        {
            _service.Atualizar(model);
            return StatusCode(201);
        }
    }
}
