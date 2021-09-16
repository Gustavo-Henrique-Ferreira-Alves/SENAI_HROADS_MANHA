using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;

namespace senai.hroads.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ClassesHabRepository
    /// </summary>
    interface IClassesHabRepository
    {
        /// <summary>
        /// Listar todas as classes de habilidade
        /// </summary>
        /// <returns>Lista de classes de habilidade</returns>
        List<ClassesHabilidade> Listar();

        /// <summary>
        /// Buscar as classes de habilidade pelo ID
        /// </summary>
        /// <param name="idClasseHab">ID das classes de habilidade que será buscado</param>
        /// <returns>Classe de habilidade encontrada</returns>
        ClassesHabilidade BuscarPorId(int idClasseHab);

        /// <summary>
        /// Cadastrar uma nova classe de habilidade
        /// </summary>
        /// <param name="novaClasseHab">Objeto novaClasseHab com as todas as informações</param>
        void Cadastrar(ClassesHabilidade novaClasseHab);

        /// <summary>
        /// Atualizar os dados de uma classe de habilidade
        /// </summary>
        /// <param name="idClasseHab">ID da classe de habilidade que será atualizada</param>
        /// <param name="classeHabAtualizado">Objeto classeHabAtualizado com as novas informações</param>
        void Atualizar(int idClasseHab, ClassesHabilidade classeHabAtualizado);

        /// <summary>
        /// Deletar uma classe de habilidade
        /// </summary>
        /// <param name="idClasseHab">ID da classe de habilidade que será deletada</param>
        void Deletar(int idClasseHab);
    }
}
