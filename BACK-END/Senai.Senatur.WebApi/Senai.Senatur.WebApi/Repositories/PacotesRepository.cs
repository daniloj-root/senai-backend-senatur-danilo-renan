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
            dbo.SaveChanges();
        }

        public void Cadastrar(Pacotes novoPacote)
        {
            dbo.Pacotes.Add(novoPacote);
            dbo.SaveChanges();
        }

        public void Deletar(Pacotes pacoteEscolhido)
        {
            dbo.Pacotes.Remove(pacoteEscolhido);
            dbo.SaveChanges();
        }

        public IEnumerable<Pacotes> ListarPorCidade(string nomeCidade)
        {
            return dbo.Pacotes.Where(p => p.NomeCidade.Contains(nomeCidade));
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

        public IEnumerable<Pacotes> ListarOrdenadoPorPrecoDesc()
        {
            return dbo.Pacotes.OrderByDescending(x => x.Valor);
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
