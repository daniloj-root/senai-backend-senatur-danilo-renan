using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuariosRepository : RepositoryBase, IUsuariosRepository
    {
        public IEnumerable<Usuarios> ListarTodos()
        {
            return dbo.Usuarios.Include(x => x.IdTipoUsuarioNavigation);
        }

        public Usuarios ListarPorId(int id)
        {
            var usuario = dbo.Usuarios.FirstOrDefault(x => x.IdUsuario == id);

            usuario.IdTipoUsuarioNavigation = dbo.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == usuario.IdTipoUsuario);

            return usuario;
        }

        public Usuarios ListarPorEmailSenha(string email, string senha)
        {
            return dbo.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            dbo.Usuarios.Add(novoUsuario);
            dbo.SaveChanges();
        }

        public void Atualizar(Usuarios usuarioAtualizado)
        {
            dbo.Usuarios.Update(usuarioAtualizado);
            dbo.SaveChanges();
        }

        public void Deletar(Usuarios usuarioEscolhido)
        {
            dbo.Usuarios.Remove(usuarioEscolhido);
            dbo.SaveChanges();
        }
    }
}
