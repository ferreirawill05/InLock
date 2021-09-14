using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_WebApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }
        public EstudioDomain Estudio { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string nomeJogo { get; set; }
        public string descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo é obrigatório")]
        public double valor { get; set; }
    }
}
