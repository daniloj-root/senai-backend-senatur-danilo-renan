using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]

    public class PacotesController : Controller
    {
        private IPacotesRepository _pacotesRepository { get; set; }

        public PacotesController()
        {
            _pacotesRepository = new PacotesRepository();
        }


        /// <summary>
        /// Lista todos os pacotes ativos
        /// </summary>
        /// <returns>Uma lista de Pacotes ativos</returns>
        /// 
        
        [HttpGet("pesquisar/ativos")]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarAtivos()
        {
            try
            {
                var listaPacotes = _pacotesRepository.ListarAtivos();
                return Ok(listaPacotes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Lista todos os pacotes ativos
        /// </summary>
        /// <returns>Uma lista de Pacotes ativos</returns>
        // GET api/pesquisar/inativos
        [HttpGet("pesquisar/inativos")]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarInativos(int id)
        {
            try
            {
                var listaPacotes = _pacotesRepository.ListarInativos();
                return Ok(listaPacotes);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Lista todos os pacotes, mas ordenados por preço de forma ascendente
        /// </summary>
        /// <returns>Uma lista de Pacotes ordenados por preço de forma ascendente</returns>
        // GET api/pesquisar/ordenar
        [HttpGet("pesquisar/ordenar/asc/")]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarOrdenadoPorPreco()
        {
            try
            {
                var listaPacotes = _pacotesRepository.ListarOrdenadoPorPreco();
                return Ok(listaPacotes);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Lista todos os pacotes, mas ordenados por preço de fkrma decrescente
        /// </summary>
        /// <returns>Uma lista de Pacotes ordenados por preço de forma decrescente</returns>
        // GET api/pesquisar/ordenar
        [HttpGet("pesquisar/ordenar/desc/")]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarOrdenadoPorPrecoDesc()
        {
            try
            {
                var listaPacotes = _pacotesRepository.ListarOrdenadoPorPrecoDesc();
                return Ok(listaPacotes);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// Lista todos os pacotes de uma cidade
        /// </summary>
        /// <returns>Uma lista de Pacotes de uma cidade específicia</returns>
        // GET api/pesquisar/cidade/{nomecidade}
        [HttpGet("pesquisar/cidade/{nomecidade}")]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarPorCidade(string nomeCidade)
        {
            try
            {
                var listaPacotes = _pacotesRepository.ListarPorCidade(nomeCidade);
                return Ok(listaPacotes);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Lista todos pacotes 
        /// </summary>
        /// <returns>Uma lista de Pacotes</returns>
        // GET api/Pacotes
        [HttpGet]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarTodos()
        {
            try
            {
                var listaPacotes = _pacotesRepository.ListarTodos();
                return Ok(listaPacotes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        /// <summary>
        /// Cadastrar um pacote 
        /// </summary>
        /// <returns>StatusCode 201</returns>
        // POST api/Pacotes
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Pacotes novoPacote)
        {
            try
            {
                _pacotesRepository.Cadastrar(novoPacote);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Atualiza um pacote
        /// </summary>
        /// <param name="pacoteAtualizado">objeto Pacote com um ID existente e as informações atualizadas</param>
        /// <returns>StatusCode 200</returns>
        // PUT api/Pacotes/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(Pacotes pacoteAtualizado)
        {
            var pacoteEscolhido = _pacotesRepository.ListarPorId(pacoteAtualizado.IdPacote);

            if (pacoteEscolhido == null)
            {
                return NotFound();
            }

            _pacotesRepository.Atualizar(pacoteAtualizado);
            return Ok();

        }

        /// <summary>
        /// Deleta um pacote
        /// </summary>
        /// <param name="id">ID do pacote</param>
        /// <returns>StatusCode 200</returns>
        // DELETE api/Pacotes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            var pacoteEscolhido = _pacotesRepository.ListarPorId(id);

            if (pacoteEscolhido == null)
            {
                return NotFound();
            }

            try
            {
                _pacotesRepository.Deletar(pacoteEscolhido);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        /// <summary>
        /// Lista pacotes por Id
        /// </summary>
        /// <returns>Uma um pacote</returns>
        // GET api/Pacotes
        [HttpGet("{id}")]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                var listaPorID = _pacotesRepository.ListarPorId(id);
                return Ok(listaPorID);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
