using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EstoqueAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using EstoqueAPI.Repositories;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository produtoRepository;

        public ProdutoController(IConfiguration configuration)
        {
            produtoRepository = new ProdutoRepository(configuration);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task Cadastrar([FromBody] Produto produto)
        {
            await produtoRepository.Cadastrar(produto);
        }

        [HttpPost]
        [Route("Atualizar")]
        public async Task Atualizar([FromBody] Produto produto)
        {
            await produtoRepository.Atualizar(produto);
        }

        [HttpPost]
        [Route("Excluir")]
        public async Task Excluir(string nome)
        {
            await produtoRepository.Excluir(nome);
        }

        [HttpGet]
        [Route("BuscarTodos")]
        public async Task<IEnumerable<Produto>> BuscarTodos()
        {
            return await produtoRepository.BuscarTodos();
        }

        [HttpGet]
        [Route("BuscarPorNome")]
        public async Task<Produto> BuscarPorNome(string nome)
        {
            return await produtoRepository.BuscarPorNome(nome);
        }
    }
}