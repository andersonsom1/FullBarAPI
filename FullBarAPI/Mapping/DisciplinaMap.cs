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
    public class DisciplinaMap : ClassMapping<Disciplina>
    {
        public DisciplinaMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
            });
            Property(p => p.NomeDisciplina, p =>
            {
                p.Length(200);
                p.Type(NHibernateUtil.String);
                p.Column("NomeDisciplina");
                p.NotNullable(true);
            });
            Property(p => p.NotaMinimaAprovacao, p =>
            {
                p.Type(NHibernateUtil.Double);
                p.Column("NotaMinimaAprovacao");
                p.NotNullable(true);
            });
            Property(p => p.IdCurso, p =>
            {
                p.Length(200);
                p.Type(NHibernateUtil.Int32);
                p.Column("IdCurso");
                p.NotNullable(true);
            });

            Table("tbDisciplina");
        }
    }
}
