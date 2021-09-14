using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_InLock_WebApi.Domains;
using senai_InLock_WebApi.Interfaces;
using senai_InLock_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EstudiosController : ControllerBase
    {

        private IEstudioRepository _EstudioRepository { get; set; }

        public EstudiosController()
        {
            _EstudioRepository = new EstudioRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<EstudioDomain> ListaEstudio = _EstudioRepository.ListarTodos();

            return Ok(ListaEstudio);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _EstudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado!");
            }

            return Ok(estudioBuscado);
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            _EstudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _EstudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Estudio não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _EstudioRepository.AtualizarIdUrl(id, estudioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(EstudioDomain estudioAtualizado)
        {
            if (estudioAtualizado.nomeEstudio == null || estudioAtualizado.idEstudio == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome do Estudio ou id do Estudio não foi informado!"
                    }
                );
            }

            EstudioDomain EstudioBuscado = _EstudioRepository.BuscarPorId(estudioAtualizado.idEstudio);
            
            if (EstudioBuscado != null)
            {
                try
                {
                    _EstudioRepository.AtualizarIdCorpo(estudioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound(
                    new
                    {
                        mensagemErro = "Estudio não encontrado!",
                        codErro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _EstudioRepository.Deletar(id);

            return StatusCode(204);
        }
    }

}
