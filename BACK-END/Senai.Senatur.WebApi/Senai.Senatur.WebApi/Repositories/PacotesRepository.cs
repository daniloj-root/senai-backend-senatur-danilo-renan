using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacotesRepository : RepositoryBase, IPacotesRepository
    {
        public void Atualizar(Pacotes pacoteAtualizado)
        {
            dbo.Pacotes.Update(pacoteAtualizado);
        }

        public void Cadastrar(Pacotes novoPacote)
        {
            dbo.Pacotes.Add(novoPacote);
        }

        public void Deletar(Pacotes pacoteEscolhido)
        {
            dbo.Pacotes.Remove(pacoteEscolhido);
        }

        public IEnumerable<Pacotes> ListarAtivos()
        {
            return dbo.Pacotes.Where(p => p.Ativo == true);
        }

        public IEnumerable<Pacotes> ListarInativos()
        {
            return dbo.Pacotes.Where(p => p.Ativo == false);
        }

        public IEnumerable<Pacotes> ListarOrdenadoPorPreco()
        {
            return dbo.Pacotes.OrderBy(x => x.Valor);
        }

        public Pacotes ListarPorId(int id)
        {
            return dbo.Pacotes.FirstOrDefault(x => x.IdPacote == id);
        }

        public IEnumerable<Pacotes> ListarTodos()
        {
            return dbo.Pacotes;
        }
    }
}
