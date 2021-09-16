using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;

namespace senai.hroads.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ClasseRepository
    /// </summary>
    interface IClasseRepository
    {
        /// <summary>
        /// Listar todas as classes
        /// </summary>
        /// <returns>Lista de classes</returns>
        List<Classe> Listar();

        /// <summary>
        /// Buscar classe pelo ID
        /// </summary>
        /// <param name="idClasse">ID da classe que será buscado</param>
        /// <returns>Classe encontrada</returns>
        Classe BuscarPorId(int idClasse);

        /// <summary>
        /// Cadastrar uma classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse com as todas as informações</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualizar os dados de uma classe
        /// </summary>
        /// <param name="idClasse">ID da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizado com as novas informações</param>
        void Atualizar(int idClasse, Classe classeAtualizada);

        /// <summary>
        /// Deletar uma classe
        /// </summary>
        /// <param name="idClasse">ID da classe que será deletada</param>
        void Deletar(int idClasse);
    }
}
