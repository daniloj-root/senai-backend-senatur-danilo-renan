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

<<<<<<< HEAD

=======
        // GET api/Pacotes
>>>>>>> 2999dd3b329714dfcc05ee5be0609061924fe93e
        /// <summary>
        /// Lista todos os pacotes ativos
        /// </summary>
<<<<<<< HEAD
        /// <returns>Uma lista de Pacotes ativos</returns>
        /// 
        
        [HttpGet("pesquisar/ativos")]
=======
        /// <returns>Uma lista de Pacotes</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet]

>>>>>>> 2999dd3b329714dfcc05ee5be0609061924fe93e
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

        //GET: api/pesquisar/ativos
        /// <summary>
        /// Lista todos os pacotes ativos
        /// </summary>
        /// <returns>Uma lista de Pacotes ativos</returns>
<<<<<<< HEAD
        // GET api/pesquisar/inativos
        [HttpGet("pesquisar/inativos")]
=======
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("pesquisar/ativos")]

>>>>>>> 2999dd3b329714dfcc05ee5be0609061924fe93e
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

        // GET api/pesquisar/inativos
        /// <summary>
        /// Lista todos os pacotes, mas ordenados por preço de forma ascendente
        /// </summary>
<<<<<<< HEAD
        /// <returns>Uma lista de Pacotes ordenados por preço de forma ascendente</returns>
        // GET api/pesquisar/ordenar
        [HttpGet("pesquisar/ordenar/asc/")]
=======
        /// <returns>Uma lista de Pacotes ativos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("pesquisar/inativos")]

>>>>>>> 2999dd3b329714dfcc05ee5be0609061924fe93e
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

        // GET api/pesquisar/ordenar
        /// <summary>
        /// Lista todos os pacotes, mas ordenados por preço de fkrma decrescente
        /// </summary>
<<<<<<< HEAD
        /// <returns>Uma lista de Pacotes ordenados por preço de forma decrescente</returns>
        // GET api/pesquisar/ordenar
        [HttpGet("pesquisar/ordenar/desc/")]
=======
        /// <returns>Uma lista de Pacotes ordenados por preço</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("pesquisar/ordenar")]

>>>>>>> 2999dd3b329714dfcc05ee5be0609061924fe93e
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

        // POST api/Pacotes
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

            _pacotesRepository.Atualizar(pacoteAtualizado);
            return Ok();

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
