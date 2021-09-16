using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdTipoUser { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUserNavigation { get; set; }
    }
}
