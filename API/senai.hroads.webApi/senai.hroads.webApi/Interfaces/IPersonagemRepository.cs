using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;

namespace senai.hroads.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo PersonagemRepository
    /// </summary>
    interface IPersonagemRepository
    {
        /// <summary>
        /// Listar todos os personagens
        /// </summary>
        /// <returns>Lista de personagens</returns>
        List<Personagem> Listar();

        /// <summary>
        /// Buscar personagem pelo ID
        /// </summary>
        /// <param name="idPersonagem">ID do personagem que será buscado</param>
        /// <returns>Personagem encontrado</returns>
        Personagem BuscarPorId(int idPersonagem);

        /// <summary>
        /// Cadastrar uma habilidade
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com as todas as informações</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualizar os dados de um personagem
        /// </summary>
        /// <param name="idPersonagem">ID do personagem que será atualizada</param>
        /// <param name="personagemAtualizado">Objeto personagemAtualizado com as novas informações</param>
        void Atualizar(int idPersonagem, Personagem personagemAtualizado);

        /// <summary>
        /// Deletar um personagem
        /// </summary>
        /// <param name="idPersonagem">ID do personagem que será deletado</param>
        void Deletar(int idPersonagem);
    }
}
