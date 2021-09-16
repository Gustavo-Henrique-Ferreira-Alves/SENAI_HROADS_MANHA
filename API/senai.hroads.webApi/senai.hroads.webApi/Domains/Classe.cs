using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            ClassesHabilidades = new HashSet<ClassesHabilidade>();
            Personagens = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        public string NomeClasse { get; set; }

        public virtual ICollection<ClassesHabilidade> ClassesHabilidades { get; set; }
        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
