using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_WebApi.Domains
{
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        [Required (ErrorMessage = "O nome do estúdio é obrigatório")]
        public string nomeEstudio { get; set; }
    }
}
