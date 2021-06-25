using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
        protected internal virtual byte[] Foto { get; set; } = null;
    }
}
