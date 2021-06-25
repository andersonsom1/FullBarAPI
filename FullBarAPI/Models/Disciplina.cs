using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Models
{
    public class Disciplina
    {
        protected internal virtual int Id { get; set; }
        public virtual string NomeDisciplina { get; set; }
        public virtual double? NotaMinimaAprovacao { get; set; }
        public virtual int IdCurso { get; set; }
    }
}
