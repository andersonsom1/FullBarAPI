using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using FullBarAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Services
{
    public class NotaAlunoService : INotaAlunoService
    {
        private readonly IRepository<NotaAluno> _repository;

        public NotaAlunoService(IRepository<NotaAluno> repository)
        {
            _repository = repository;
        }

        public async Task CreateNotaAluno(NotaAluno notaAluno)
        {
            try
            {
                IEnumerable<NotaAluno> listnotaAluno = _repository.FindAll(notaAluno).Result;
                if (!listnotaAluno.Any())
                    await _repository.Add(notaAluno);
                else
                    throw new Exception("Nota do aluno " + notaAluno.IdAluno + " já existente " + notaAluno.IdDisciplina);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo CreateNotaAluno " + ex.Message);
            }
        }

        public async Task<NotaAluno> FindById(int idNotaAluno)
        {
            try
            {
                return await _repository.FindById(idNotaAluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo FindById " + ex.Message);
            }
        }

        public async Task<IEnumerable<NotaAluno>> GetNotaAluno()
        {
            try
            {
                return await _repository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo GetNotaAluno " + ex.Message);
            }
        }

        public async Task UpdteNotaAluno(NotaAluno notaAluno)
        {
            try
            {
                IEnumerable<NotaAluno> listnotaAluno = _repository.FindAll(notaAluno).Result;
                listnotaAluno.FirstOrDefault(x => x.IdDisciplina.Equals(notaAluno.IdDisciplina) &&
                x.IdAluno.Equals(notaAluno.IdAluno)).Notaaluno = notaAluno.Notaaluno;
                await _repository.Update(listnotaAluno.FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo UpdteNotaAluno " + ex.Message);
            }
        }
    }
}
