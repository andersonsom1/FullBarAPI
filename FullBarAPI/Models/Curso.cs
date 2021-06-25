using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Models
{
    public class Curso
    {
        protected internal virtual int Id { get; set; }
        public virtual string NomedoCurso { get; set; }
    }
}
