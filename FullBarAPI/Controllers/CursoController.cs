using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using FullBarAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FullBarAPI.Models.AlunoStatus;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullBarAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(StatusCodeResult), 400)]
    [ProducesResponseType(typeof(StatusCodeResult), 500)]
    public class CursoController : ControllerBase
    {

        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // POST api/<CursoController>
        [HttpPost]
        public async Task<ActionResult> CreateCurso([FromBody] Curso curso)
        {
            try
            {
                await _cursoService.CreateCurso(curso);
                return Ok(true);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<NomeCurso>> GetAllCursos()
        {
            try
            {
                return Ok(await _cursoService.GetNomeCurso());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
