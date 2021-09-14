using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_WebApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public TipoUsuarioDomain TipoUsuario { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        public string email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        public string senha { get; set; }
    }
}
