using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Models;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        // GET api/Usuarios
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                var listaUsuarios = _usuariosRepository.ListarTodos();
                return Ok(listaUsuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/Usuarios/5
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                var usuario = _usuariosRepository.ListarPorId(id);
                return Ok(usuario);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/Usuarios
        [HttpPost]
        public IActionResult Cadastrar(Usuarios novoUsuario)
        {
            try
            {
                _usuariosRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //POST api/Usuarios/Login
        [HttpPost]
        public IActionResult Login(UsuarioViewModel usuarioLogando)
        {
            var usuarioLogado = _usuariosRepository.ListarPorEmailSenha(usuarioLogando.Email, usuarioLogando.Senha);

            if (usuarioLogado == null)
            {
                return NotFound("Email e/ou senha não encontrados não é/são válidos");
            }

            
        }

        // PUT api/Usuarios/5
        [HttpPut("{id}")]
        public IActionResult Atualizar(Usuarios usuarioAtualizado)
        {
            var usuarioEscolhido = _usuariosRepository.ListarPorId(usuarioAtualizado.IdUsuario);

            if (usuarioEscolhido == null)
            {
                return NotFound();
            }

            try
            {
                _usuariosRepository.Atualizar(usuarioAtualizado);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/Usuarios/5
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var usuarioEscolhido = _usuariosRepository.ListarPorId(id);

            if (usuarioEscolhido == null)
            {
                return NotFound();
            }

            try
            {
                _usuariosRepository.Deletar(usuarioEscolhido);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
