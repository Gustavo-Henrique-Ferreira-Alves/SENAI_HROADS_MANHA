using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;

namespace senai.hroads.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo HabilidadeRepository
    /// </summary>
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Listar todas as habilidades
        /// </summary>
        /// <returns>Lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Buscar habilidade pelo ID
        /// </summary>
        /// <param name="idHabilidade">ID da habilidades que será buscado</param>
        /// <returns>Habilidade encontrada</returns>
        Habilidade BuscarPorId(int idHabilidade);

        /// <summary>
        /// Cadastrar uma habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com as todas as informações</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualizar os dados de uma habilidade
        /// </summary>
        /// <param name="idHabilidade">ID da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizado">Objeto habilidadeAtualizado com as novas informações</param>
        void Atualizar(int idHabilidade, Habilidade habilidadeAtualizado);

        /// <summary>
        /// Deletar uma habilidade
        /// </summary>
        /// <param name="idHabilidade">ID da habilidade que será deletada</param>
        void Deletar(int idHabilidade);
    }
}
