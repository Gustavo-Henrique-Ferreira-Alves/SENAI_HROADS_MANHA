using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;

namespace senai.hroads.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TiposHabRepository
    /// </summary>
    interface ITiposHabRepository
    {
        /// <summary>
        /// Listar de todos tipos de habilidade
        /// </summary>
        /// <returns>Lista de tipos de habilidade</returns>
        List<TiposHabilidade> Listar();

        /// <summary>
        /// Buscar tipo de habilidade pelo ID
        /// </summary>
        /// <param name="idTipoHab">ID do tipo de habilidade que será buscado</param>
        /// <returns>Tipo de habilidade encontrado</returns>
        TiposHabilidade BuscarPorId(int idTipoHab);

        /// <summary>
        /// Cadastrar um tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHab">Objeto novoTipoHab com as todas as informações</param>
        void Cadastrar(TiposHabilidade novoTipoHab);

        /// <summary>
        /// Atualizar os dados de um tipo de habilidade 
        /// </summary>
        /// <param name="idTipoHab">ID do tipo de habilidade que será atualizado</param>
        /// <param name="tipoHabAtualizado">Objeto tipoHabAtualizado com as novas informações</param>
        void Atualizar(int idTipoHab, TiposHabilidade tipoHabAtualizado);

        /// <summary>
        /// Deletar um tipo de habilidade 
        /// </summary>
        /// <param name="idTipoHab">ID do tipo de habilidade que será deletado</param>
        void Deletar(int idTipoHab);
    }
}
