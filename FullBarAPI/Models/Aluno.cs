using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Models
{
    public class Aluno
    {
        protected internal virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string RA { get; set; }
        public virtual DateTime? Periodo { get; set; }
        public virtual string Foto { get; set; }
    }
}
