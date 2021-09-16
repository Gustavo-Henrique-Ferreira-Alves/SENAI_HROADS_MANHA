using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUser { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
