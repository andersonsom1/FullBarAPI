using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Models.Interfaces
{
    public interface IAlunoService
    {
        Task CreateAluno(Aluno aluno);
        Task<Aluno> GetAluno(int idaluno);
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(int idaluno);
        Task<IEnumerable<Aluno>> GetAluno();
        Task<IEnumerable<AlunoStatus>> GetStatusAluno(IEnumerable<Aluno> alunos, 
            IEnumerable<NotaAluno> notaAlunos, IEnumerable<Curso> cursos, 
            IEnumerable<Disciplina> disciplinas);
    }
}
