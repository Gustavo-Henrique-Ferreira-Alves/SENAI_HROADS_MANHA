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
    public class TiposUserRepository : ITiposUserRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int idTipoUser, TiposUsuario tipoUserAtualizado)
        {
            TiposUsuario tipoUserBuscado = BuscarPorId(idTipoUser);

            if (tipoUserAtualizado.Titulo != null)
            {
                tipoUserBuscado.Titulo = tipoUserAtualizado.Titulo;
            }

            ctx.TiposUsuarios.Update(tipoUserBuscado);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int idTipoUser)
        {
            return ctx.TiposUsuarios.FirstOrDefault(tu => tu.IdTipoUser == idTipoUser);
        }

        public void Cadastrar(TiposUsuario novoTipoUser)
        {
            ctx.TiposUsuarios.Add(novoTipoUser);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUser)
        {
            TiposUsuario tipoUserBuscado = BuscarPorId(idTipoUser);

            ctx.TiposUsuarios.Remove(tipoUserBuscado);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.Include(u => u.Usuarios).OrderBy(tu => tu.IdTipoUser).ToList();
        }
    }
}
