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
    public class NotaAlunoMap : ClassMapping<NotaAluno>
    {
        public NotaAlunoMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
            });
            Property(p => p.IdAluno, p =>
            {
                p.Type(NHibernateUtil.Int32);
                p.Column("IdAluno");
                p.NotNullable(true);
            });
            Property(p => p.IdDisciplina, p =>
            {
                p.Type(NHibernateUtil.Int32);
                p.Column("IdDisciplina");
                p.NotNullable(true);
            });
            Property(p => p.Notaaluno, p =>
            {
                p.Type(NHibernateUtil.Double);
                p.Column("NotaAluno");
                p.NotNullable(true);
            });
            Property(p => p.IdCurso, p =>
            {
                p.Type(NHibernateUtil.Int32);
                p.Column("IdCurso");
                p.NotNullable(true);
            });

            Table("tbNotaAluno");
        }
    }
}
