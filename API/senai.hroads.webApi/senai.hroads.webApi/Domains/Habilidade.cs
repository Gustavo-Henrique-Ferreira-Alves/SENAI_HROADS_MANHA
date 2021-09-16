using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ClassesHabilidades = new HashSet<ClassesHabilidade>();
        }

        public int IdHabilidade { get; set; }
        public int? IdTipoHab { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TiposHabilidade IdTipoHabNavigation { get; set; }
        public virtual ICollection<ClassesHabilidade> ClassesHabilidades { get; set; }
    }
}
