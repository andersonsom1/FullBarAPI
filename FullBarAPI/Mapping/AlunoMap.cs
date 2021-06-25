using FluentNHibernate.MappingModel.ClassBased;
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
    public class AlunoMap : ClassMapping<Aluno>
    {
        public AlunoMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
            });
            Property(p => p.Nome, p =>
            {
                p.Length(200);
                p.Type(NHibernateUtil.String);
                p.Column("Nome");
                p.NotNullable(true);
            });
            Property(p => p.RA, p =>
            {
                p.Length(50);
                p.Type(NHibernateUtil.String);
                p.Column("RA");
                p.NotNullable(true);
            });
            Property(p => p.Periodo, p =>
            {
                p.Length(200);
                p.Type(NHibernateUtil.DateTime);
                p.Column("Periodo");
                p.NotNullable(true);
            });

            Property(p => p.Foto, p =>
            {
                p.Type(NHibernateUtil.BinaryBlob);
                p.Column("Foto");
                p.NotNullable(false);
            });

            Table("tbAluno");
        }
    }
}
