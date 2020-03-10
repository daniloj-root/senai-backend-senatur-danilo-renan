using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET api/values
        [HttpGet]
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

        [HttpGet("")]
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

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult ListarInativos(int id)
        {
            try
            {
                var pacote = _pacotesRepository.ListarInativos();
                return Ok(pacote);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/values
        [HttpPost]
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

        // PUT api/values/5
        [HttpPut("{id}")]
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
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