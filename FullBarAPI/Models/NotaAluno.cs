using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Models
{
    public class NotaAluno
    {
        protected internal virtual int Id { get; set; }
        public virtual int IdAluno { get; set; }
        public virtual int IdDisciplina { get; set; }
        public virtual double Notaaluno { get; set; }
        protected internal virtual int IdCurso { get; set; }
    }
}
