using Microsoft.EntityFrameworkCore;
using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using senai.hroads.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int idHabilidade, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = BuscarPorId(idHabilidade);

            if (habilidadeAtualizada.NomeHabilidade != null || habilidadeAtualizada.IdTipoHab != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
                habilidadeBuscada.IdTipoHab = habilidadeAtualizada.IdTipoHab;
            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int idHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == idHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            Habilidade habilidadeBuscada = BuscarPorId(idHabilidade);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades
                .Select(h => new Habilidade()
                {
                   IdHabilidade = h.IdHabilidade,
                   IdTipoHab = h.IdTipoHab,
                   NomeHabilidade = h.NomeHabilidade,
                   ClassesHabilidades = h.ClassesHabilidades,
                   
                   IdTipoHabNavigation = new TiposHabilidade()
                   {
                      IdTipoHab = h.IdTipoHabNavigation.IdTipoHab,
                      NomeTipoHab = h.IdTipoHabNavigation.NomeTipoHab,
                   }
                })
                    .OrderBy(h => h.IdHabilidade).ToList();
        }
    }
}
