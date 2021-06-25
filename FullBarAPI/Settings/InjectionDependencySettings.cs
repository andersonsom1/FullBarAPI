using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using FullBarAPI.Repository;
using FullBarAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Settings
{
    public static class InjectionDependencySettings
    {
        public static void AddInjectionDependencyConfiguration(IServiceCollection services)
        {
            // COMMANDS
            services.AddTransient<IAlunoService, AlunoService>();
            services.AddTransient<IRepository<Aluno>, AlunoRepository>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<IRepository<Curso>, CursoRepository>();
            services.AddTransient<IDisciplinaService, DisciplinaService>();
            services.AddTransient<IRepository<Disciplina>, DisciplinaRepository>();
            services.AddTransient<INotaAlunoService, NotaAlunoService>();
            services.AddTransient<IRepository<NotaAluno>, NotaAlunoRepository>();
        }
    }

}
