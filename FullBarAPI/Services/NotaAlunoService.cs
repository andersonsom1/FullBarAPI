using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
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

        public async Task CreateNotaAluno(NotaAluno notaaluno)
        {
            try
            {
                await _repository.Add(notaaluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo CreateNotaAluno " + ex.Message);
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
    }
}
