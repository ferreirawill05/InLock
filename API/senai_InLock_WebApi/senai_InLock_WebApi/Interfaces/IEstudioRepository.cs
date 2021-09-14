using senai_InLock_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_WebApi.Interfaces
{
    interface IEstudioRepository
    {
        //Lista todos os Estudios
        List<EstudioDomain> ListarTodos();

        //Buscar Pelo Id
        EstudioDomain BuscarPorId(int idEstudio);

        //Cadastrar um Jogo
        void Cadastrar(EstudioDomain novoEstudio);

        //Atualizar pelo corpo da requisição(JSON)
        void AtualizarIdCorpo(EstudioDomain estudioAtualizado);

        //Atualizar pela Url
        void AtualizarIdUrl(int idEstudio, EstudioDomain estudioAtualizado);

        //Deletar um Jogo
        void Deletar(int idEstudio);
    }
}
