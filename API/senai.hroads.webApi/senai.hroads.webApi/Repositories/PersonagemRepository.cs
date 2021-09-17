using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using senai.hroads.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int idPersonagem, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = BuscarPorId(idPersonagem);

            if (personagemAtualizado != null)
            {
                personagemBuscado.IdClasse = personagemAtualizado.IdClasse;
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
                personagemBuscado.QtndVida = personagemAtualizado.QtndVida;
                personagemBuscado.QtndMana = personagemAtualizado.QtndMana;
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
                personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;
            }

            ctx.Personagens.Update(personagemBuscado);

            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int idPersonagem)
        {
            return ctx.Personagens.FirstOrDefault(p => p.IdPersonagem == idPersonagem);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagens.Add(novoPersonagem);

            ctx.SaveChanges();
        }

        public void Deletar(int idPersonagem)
        {
            Personagem personagemBuscado = BuscarPorId(idPersonagem);

            ctx.Personagens.Remove(personagemBuscado);

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagens.OrderBy(p => p.IdPersonagem).ToList();
        }
    }
}
