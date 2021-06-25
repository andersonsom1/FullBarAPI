using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FullBarAPI.Models.AlunoStatus;

namespace FullBarAPI.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IRepository<Disciplina> _repository;

        public DisciplinaService(IRepository<Disciplina> repository)
        {
            _repository = repository;
        }

        public async Task CreateDisciplina(Disciplina disciplina)
        {
            try
            {
                await _repository.Add(disciplina);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo CreateCurso " + ex.Message);
            }
        }

        public async Task<IEnumerable<Disciplina>> GetDisciplina()
        {
            try
            {
                return await _repository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo GetDisciplina " + ex.Message);
            }
        }

        public async Task<IEnumerable<NomeDisciplina>> GetNomeDisciplina()
        {
            try
            {
                List<NomeDisciplina> nomeDisciplinas = new List<NomeDisciplina>();

                IEnumerable<Disciplina> disciplinas = await _repository.FindAll();

                disciplinas.ToList().ForEach(x =>
                {
                    nomeDisciplinas.Add(new NomeDisciplina()
                    {
                        Id = x.Id,
                        IdCurso = x.IdCurso,
                        NomedaDisciplina = x.NomeDisciplina,
                        NotaMinimaAprovacao = x.NotaMinimaAprovacao
                    });
                });

                return nomeDisciplinas;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo GetCurso " + ex.Message);
            }
        }
    }
}
