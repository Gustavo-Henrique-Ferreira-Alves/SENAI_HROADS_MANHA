using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;

namespace senai.hroads.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TiposUserRepository
    /// </summary>
    interface ITiposUserRepository
    {
        /// <summary>
        /// Listar de todos tipos de usuários
        /// </summary>
        /// <returns>Lista de tipos de usuários</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Buscar tipo de usuário pelo ID
        /// </summary>
        /// <param name="idTipoUser">ID do tipo de usuário que será buscado</param>
        /// <returns>Tipo de usuário encontrado</returns>
        TiposUsuario BuscarPorId(int idTipoUser);

        /// <summary>
        /// Cadastrar um tipo de usuário
        /// </summary>
        /// <param name="novoTipoUser">Objeto novoTipoUser com as todas as informações</param>
        void Cadastrar(TiposUsuario novoTipoUser);

        /// <summary>
        /// Atualizar os dados de um tipo de usuário 
        /// </summary>
        /// <param name="idTipoUser">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUserAtualizado">Objeto tipoUserAtualizado com as novas informações</param>
        void Atualizar(int idTipoUser, TiposUsuario tipoUserAtualizado);

        /// <summary>
        /// Deletar um tipo de usuário
        /// </summary>
        /// <param name="idTipoUser">ID do tipo de usuário que será deletado</param>
        void Deletar(int idTipoUser);
    }
}
