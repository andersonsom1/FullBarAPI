using FullBarAPI.Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Mapping
{
    public class CursoMap : ClassMapping<Curso>
    {
        public CursoMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
            });
            Property(p => p.NomedoCurso, p =>
            {
                p.Length(200);
                p.Type(NHibernateUtil.String);
                p.Column("NomeCurso");
                p.NotNullable(true);
            });

            Table("tbCurso");
        }
    }
}
