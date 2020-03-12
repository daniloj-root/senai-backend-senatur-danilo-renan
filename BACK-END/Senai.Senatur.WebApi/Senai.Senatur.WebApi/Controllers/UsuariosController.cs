using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        /// <summary>
        /// Busca todos os usuários no banco de dados e seus respectivos tipos
        /// </summary>
        /// <returns>objetos Usuarios populados com todos os usuários do banco de dados - StatusCode 200</returns>
        // GET api/Usuarios

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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

        /// <summary>
        /// Procura um usuário pelo seu respectivo ID
        /// </summary>
        /// <param name="id">ID do usuário desejado</param>
        /// <returns>objeto Usuários populado com o usuário desejado - StatusCode 200</returns>
        // GET api/Usuarios/5

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">objeto do tipo Usuarios</param>
        /// <returns>Status Code 201</returns>
        /// 

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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
        /// <summary>
        /// Faz o login de um usuário
        /// </summary>
        /// <param name="usuarioLogando">objeto Usuarios populado com email e senha</param>
        /// <returns>Token de autorização JWT - StatusCode 200</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPost("login")]

        public IActionResult Login(UsuarioViewModel usuarioLogando)
        {
            var usuarioLogado = _usuariosRepository.ListarPorEmailSenha(usuarioLogando.Email, usuarioLogando.Senha);

            if (usuarioLogado == null)
            {
                return NotFound("Email e/ou senha não encontrados não é/são válidos");
            }
            
             var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.IdTipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                new Claim(ClaimTypes.Role, usuarioLogado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-senatur"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senai.Senatur.WebApi",
                audience: "Senai.Senatur.WebApi",
                claims: claims,                   
                expires: DateTime.Now.AddMinutes(15), 
                signingCredentials: creds
            );

            // Retorna Ok com o token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        // PUT api/Usuarios/5
        /// <summary>
        /// Atualiza um usuário no banco de dados
        /// </summary>
        /// <param name="usuarioAtualizado">objeto Usuários com um id existente e as informações a serem atualizadas</param>
        /// <returns>StatusCode 200</returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        /// <summary>
        /// Deleta um usuário do banco de dados
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>StatusCode 200</returns>
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
