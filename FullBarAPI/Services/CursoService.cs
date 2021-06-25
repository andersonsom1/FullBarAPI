using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FullBarAPI.Models.AlunoStatus;

namespace FullBarAPI.Services
{
    public class CursoService : ICursoService
    {
        private readonly IRepository<Curso> _repository;

        public CursoService(IRepository<Curso> repository)
        {
            _repository = repository;
        }


        public async Task CreateCurso(Curso curso)
        {
            try
            {
                await _repository.Add(curso);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo CreateCurso " + ex.Message);
            }
        }

        public async Task<IEnumerable<Curso>> GetCurso()
        {
            try
            {
                return await _repository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo GetCurso " + ex.Message);
            }
        }

        public async Task<IEnumerable<NomeCurso>> GetNomeCurso()
        {
            try
            {
                List<NomeCurso> nomeCursos = new List<NomeCurso>();

                IEnumerable<Curso> cursos = await _repository.FindAll();

                cursos.ToList().ForEach(x =>
                {
                    nomeCursos.Add(new NomeCurso()
                    {
                        IdCurso = x.Id,
                        NomedoCurso = x.NomedoCurso
                    });
                });

                return nomeCursos;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo GetNomeCurso " + ex.Message);
            }
        }
    }
}
