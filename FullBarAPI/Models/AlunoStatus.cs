using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Models
{
    public class AlunoStatus
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RA { get; set; }
        public DateTime? Periodo { get; set; }
        public string Foto { get; set; }
        public NomeCurso CursoNome { get; set; }
        public IEnumerable<NotaAlunoDisciplina> notaAlunoDisciplinas { get; set; }

        public class NotaAlunoDisciplina
        {
            public int IdDisciplina { get; set; }
            public string NomeDisciplina { get; set; }
            public double AlunoNotaDisciplina { get; set; }
            public string Status { get; set; }
        }

        public class NomeDisciplina
        {
            public int Id { get; set; }
            public string NomedaDisciplina { get; set; }
            public virtual double? NotaMinimaAprovacao { get; set; }
            public virtual int IdCurso { get; set; }
        }

        public class NomeCurso
        {
            public int IdCurso { get; set; }
            public string NomedoCurso { get; set; }
        }

    }


}
