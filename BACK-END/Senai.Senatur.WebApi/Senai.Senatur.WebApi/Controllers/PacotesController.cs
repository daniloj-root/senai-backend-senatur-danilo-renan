using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    public class PacotesController : Controller
    {
        private IPacotesRepository _pacotesRepository { get; set; }

        public PacotesController()
        {
            _pacotesRepository = new PacotesRepository();
        }

        // GET api/Pacotes
        /// <summary>
        /// Lista todos pacotes 
        /// </summary>
        /// <returns>Uma lista de Pacotes</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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

        //GET: api/pesquisar/ativos
        /// <summary>
        /// Lista todos os pacotes ativos
        /// </summary>
        /// <returns>Uma lista de Pacotes ativos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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

        // GET api/pesquisar/inativos
        /// <summary>
        /// Lista todos os pacotes ativos
        /// </summary>
        /// <returns>Uma lista de Pacotes ativos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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

        // GET api/pesquisar/ordenar
        /// <summary>
        /// Lista todos os pacotes, mas ordenados por preço
        /// </summary>
        /// <returns>Uma lista de Pacotes ordenados por preço</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("pesquisar/ordenar")]

        [Authorize(Roles = "1, 2")]
        public IActionResult ListarOrdenadoPorPreco(int id)
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

        // POST api/Pacotes
        /// <summary>
        /// Cadastrar um pacote 
        /// </summary>
        /// <returns>StatusCode 201</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")]

        [Authorize(Roles = "1")]
        public IActionResult Atualizar(Pacotes pacoteAtualizado)
        {
            var pacoteEscolhido = _pacotesRepository.ListarPorId(pacoteAtualizado.IdPacote);

            if (pacoteEscolhido == null)
            {
                return NotFound();
            }

            try
            {
                _pacotesRepository.Atualizar(pacoteAtualizado);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deleta um pacote
        /// </summary>
        /// <param name="id">ID do pacote</param>
        /// <returns>StatusCode 200</returns>
        // DELETE api/Pacotes/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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
    }
}