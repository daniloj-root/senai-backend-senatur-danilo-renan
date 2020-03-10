using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        IEnumerable<Usuarios> ListarTodos();
        Usuarios ListarPorId(int id);
        Usuarios ListarPorEmailSenha(string senha, string email);
        void Cadastrar(Usuarios novoUsuario);
        void Atualizar(Usuarios usuarioAtualizado);
        void Deletar(Usuarios usuarioEscolhido);
    }
}
