using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        IEnumerable<Pacotes> ListarTodos();
        IEnumerable<Pacotes> ListarAtivos();
        IEnumerable<Pacotes> ListarInativos();
        IEnumerable<Pacotes> ListarPorCidade(string nomeCidade);
        IEnumerable<Pacotes> ListarOrdenadoPorPreco();
        IEnumerable<Pacotes> ListarOrdenadoPorPrecoDesc();
        Pacotes ListarPorId(int id);
        void Cadastrar(Pacotes novoPacote);
        void Atualizar(Pacotes pacoteAtualizado);
        void Deletar(Pacotes pacoteEscolhido);
    }
}
