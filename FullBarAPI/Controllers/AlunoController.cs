using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using FullBarAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FullBarAPI.Models.AlunoStatus;

namespace FullBarAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(StatusCodeResult), 400)]
    [ProducesResponseType(typeof(StatusCodeResult), 500)]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly INotaAlunoService _notaAlunoService;
        private readonly ICursoService _cursoService;
        private readonly IDisciplinaService _disciplinaService;

        public AlunoController(IAlunoService alunoService,
            INotaAlunoService notaAlunoService,
            ICursoService cursoService,
            IDisciplinaService disciplinaService)
        {
            _alunoService = alunoService;
            _notaAlunoService = notaAlunoService;
            _cursoService = cursoService;
            _disciplinaService = disciplinaService;
        }

        [HttpGet]
        public async Task<ActionResult<AlunoStatus>> GetAllAlunos()
        {
            try
            {
                IEnumerable<Aluno> alunos = await _alunoService.GetAluno();
                IEnumerable<Curso> cursos = await _cursoService.GetCurso();
                IEnumerable<NotaAluno> notaAlunos = await _notaAlunoService.GetNotaAluno();
                IEnumerable<Disciplina> disciplinas = await _disciplinaService.GetDisciplina();

                return Ok(await _alunoService.GetStatusAluno(alunos, notaAlunos, cursos, disciplinas));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<AlunoStatus>> GetFilterAlunos(string NomeAluno, string RA, string NomeCurso, string Status)
        {
            try
            {
                IEnumerable<Aluno> alunos = await _alunoService.GetAluno();
                IEnumerable<Curso> cursos = await _cursoService.GetCurso();
                IEnumerable<NotaAluno> notaAlunos = await _notaAlunoService.GetNotaAluno();
                IEnumerable<Disciplina> disciplinas = await _disciplinaService.GetDisciplina();


                IEnumerable<AlunoStatus> alunoStatus = await _alunoService.GetStatusAluno(alunos, notaAlunos, cursos, disciplinas);

                if(!String.IsNullOrEmpty(NomeAluno))
                {
                    alunoStatus = alunoStatus.Where(x => x.Nome.ToUpper().Contains(NomeAluno.ToUpper()));
                }
                if (!String.IsNullOrEmpty(RA))
                {
                    alunoStatus = alunoStatus.Where(x => x.RA.ToUpper().Contains(RA.ToUpper()));
                }
                if (!String.IsNullOrEmpty(NomeCurso))
                {
                    alunoStatus = alunoStatus.Where(x => x.CursoNome != null && x.CursoNome.NomedoCurso.ToUpper().Contains(NomeCurso.ToUpper()));
                }

                if (!String.IsNullOrEmpty(Status))
                {
                    alunoStatus.ToList().ForEach(x =>
                    {                      
                        x.notaAlunoDisciplinas = x.notaAlunoDisciplinas.Where(w => !String.IsNullOrEmpty(w.Status) && w.Status.ToUpper().Contains(Status.ToUpper()));
                    });

                    alunoStatus = alunoStatus.Where(x => x.notaAlunoDisciplinas.Any(a => a.Status.ToUpper().Contains(Status.ToUpper()))); ;
                }

                return Ok(alunoStatus);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddAluno([FromBody] Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return Ok(true);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        [Route("foto")]
        public async Task<ActionResult> AddImageAluno(IFormFile foto, int idAluno)
        {
            try
            {
                await _alunoService.AssociaFoto(await _alunoService.GetAluno(idAluno),foto);

                return Ok(true);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Aluno>> UpdateAluno([FromBody] Aluno aluno, int id)
        {
            try
            {
                Aluno exist = await _alunoService.GetAluno(id);

                if (exist != null)
                {
                    aluno.Id = id;
                    await _alunoService.UpdateAluno(aluno);
                    return Ok(await _alunoService.GetAluno(id));
                }
                else
                {
                    aluno.Id = id;
                    return NotFound(aluno);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            try
            {
                Aluno exist = await _alunoService.GetAluno(id);

                if (exist != null)
                {
                    await _alunoService.DeleteAluno(id);
                    return Ok(exist);
                }
                else
                {
                    return NotFound(id);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }

}

