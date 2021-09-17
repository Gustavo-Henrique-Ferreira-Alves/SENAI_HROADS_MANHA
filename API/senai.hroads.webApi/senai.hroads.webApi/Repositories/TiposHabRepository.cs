using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using senai.hroads.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Repositories
{
    public class TiposHabRepository : ITiposHabRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int idTipoHab, TiposHabilidade tipoHabAtualizado)
        {
            TiposHabilidade tipoHabBuscado = BuscarPorId(idTipoHab);

            //if (tipoHabAtualizado.NomeClasse != null)
            {
                //tipoHabBuscado.NomeClasse = tipoHabAtualizado.NomeClasse;
            }

            ctx.TiposHabilidades.Update(tipoHabBuscado);

            ctx.SaveChanges();
        }

        public TiposHabilidade BuscarPorId(int idTipoHab)
        {
            return ctx.TiposHabilidades.FirstOrDefault(th => th.IdTipoHab == idTipoHab);
        }

        public void Cadastrar(TiposHabilidade novoTipoHab)
        {
            ctx.TiposHabilidades.Add(novoTipoHab);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoHab)
        {
            TiposHabilidade tipoHabBuscado = BuscarPorId(idTipoHab);

            ctx.TiposHabilidades.Remove(tipoHabBuscado);

            ctx.SaveChanges();
        }

        public List<TiposHabilidade> Listar()
        {
            return ctx.TiposHabilidades.OrderBy(th => th.IdTipoHab).ToList();
        }
    }
}
