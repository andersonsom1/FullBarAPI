using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Models.Interfaces
{
    public interface INotaAlunoService
    {
        Task CreateNotaAluno(NotaAluno aluno);
        Task<NotaAluno> FindById(int idNotaAluno);
        Task UpdteNotaAluno(NotaAluno aluno);
        Task<IEnumerable<NotaAluno>> GetNotaAluno();
    }
}
