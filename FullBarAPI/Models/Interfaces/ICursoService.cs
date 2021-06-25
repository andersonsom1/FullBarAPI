using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FullBarAPI.Models.AlunoStatus;

namespace FullBarAPI.Models.Interfaces
{
    public interface ICursoService
    {
        Task CreateCurso(Curso curso);
        Task<IEnumerable<Curso>> GetCurso();
        Task<IEnumerable<NomeCurso>> GetNomeCurso();
    }
}
