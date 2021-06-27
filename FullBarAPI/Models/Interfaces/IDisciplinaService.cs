using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FullBarAPI.Models.AlunoStatus;

namespace FullBarAPI.Models.Interfaces
{
    public interface IDisciplinaService
    {
        Task CreateDisciplina(Disciplina curso);
        Task<IEnumerable<Disciplina>> GetDisciplina();
        Task<Disciplina> GetDisciplinaById(int idDisciplina);
        Task<IEnumerable<NomeDisciplina>> GetNomeDisciplina();
    }
}
