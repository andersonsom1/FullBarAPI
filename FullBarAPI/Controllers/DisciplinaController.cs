using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
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
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDisciplina([FromBody] Disciplina disciplina)
        {
            try
            {
                await _disciplinaService.CreateDisciplina(disciplina);
                return Ok(true);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<NomeDisciplina>> GetAllDisciplinas()
        {
            try
            {
                return Ok(await _disciplinaService.GetNomeDisciplina());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
