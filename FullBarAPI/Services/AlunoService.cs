using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static FullBarAPI.Models.AlunoStatus;


namespace FullBarAPI.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IRepository<Aluno> _repository;

        public AlunoService(IRepository<Aluno> repository)
        {
            _repository = repository;
        }

        public async Task CreateAluno(Aluno aluno)
        {
            try
            {
                await _repository.Add(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo CreateAluno " + ex.Message);
            }
        }

        public async Task<IEnumerable<Aluno>> GetAluno()
        {
            try
            {
                return await _repository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo GetAluno " + ex.Message);
            }
        }

        public async Task<Aluno> GetAluno(int idaluno)
        {
            try
            {
                return await _repository.FindById(idaluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo GetAluno " + ex.Message);
            }
        }

        public async Task<IEnumerable<AlunoStatus>> GetStatusAluno(IEnumerable<Aluno> alunos, IEnumerable<NotaAluno> notaAlunos, IEnumerable<Curso> cursos, IEnumerable<Disciplina> disciplinas)
        {
            List<AlunoStatus> alunoStatus = new List<AlunoStatus>();

            try
            {
                alunos.ToList().ForEach(a =>
                {
                    alunoStatus.Add(new AlunoStatus()
                    {
                        Id = a.Id,
                        Nome = a.Nome,
                        Foto = a.Foto != null ? ConverteFoto(a) : null,
                        Periodo = a.Periodo,
                        RA = a.RA,
                        CursoNome = SetCurso(a.Id, notaAlunos, cursos),
                        notaAlunoDisciplinas = SetNotaAlunoDisciplina(a.Id, notaAlunos, disciplinas)
                    });
                });

                return await Task.FromResult(alunoStatus);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo GetStatusAluno " + ex.Message);
            }
        }

        private string ConverteFoto(Aluno aluno)
        {
            try
            {
                string file = $"{AppDomain.CurrentDomain.BaseDirectory}Foto\\{aluno.Nome}{aluno.Id}";
                FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate);
                fileStream.Write(aluno.Foto, 0, aluno.Foto.Length);
                fileStream.Flush();
                fileStream.Close();
                return file;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo ConverteFoto " + ex.Message);
            }
        }

        private IEnumerable<NotaAlunoDisciplina> SetNotaAlunoDisciplina(int idaluno, IEnumerable<NotaAluno> notaAlunos, IEnumerable<Disciplina> disciplinas)
        {
            List<NotaAlunoDisciplina> listnotaalunodisciplina = new List<NotaAlunoDisciplina>();

            try
            {
                notaAlunos.Where(x => x.IdAluno.Equals(idaluno)).ToList().ForEach(na =>
                {
                    listnotaalunodisciplina.Add(new NotaAlunoDisciplina()
                    {
                        IdDisciplina = na.IdDisciplina,
                        NomeDisciplina = disciplinas.FirstOrDefault(d => d.Id.Equals(na.IdDisciplina)).NomeDisciplina,
                        AlunoNotaDisciplina = na.Notaaluno,
                        Status = na.Notaaluno > disciplinas.FirstOrDefault(d => d.Id.Equals(na.IdDisciplina)).NotaMinimaAprovacao ? "Aprovado" : "Reprovado",
                    });
                });

                return listnotaalunodisciplina;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo SetCurso " + ex.Message);
            }
        }

        private NomeCurso SetCurso(int idaluno, IEnumerable<NotaAluno> notaAlunos, IEnumerable<Curso> cursos)
        {
            try
            {
                int idCurso = notaAlunos.Where(s => s.IdAluno.Equals(idaluno)).Select(x => x.IdCurso).Distinct().ToList().FirstOrDefault();

                Curso curso = cursos.FirstOrDefault(c => c.Id.Equals(idCurso));

                if (curso != null)
                {
                    return new NomeCurso()
                    {
                        IdCurso = curso.Id,
                        NomedoCurso = curso.NomedoCurso
                    };
                }
                else
                    return (null);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo SetCurso " + ex.Message);
            }

        }

        public async Task UpdateAluno(Aluno aluno)
        {
            try
            {
                await _repository.Update(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo UpdateAluno " + ex.Message);
            }
        }

        public async Task DeleteAluno(int idaluno)
        {
            try
            {
                await _repository.Remove(idaluno);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo DeleteAluno " + ex.Message);
            }
        }

        public async Task AssociaFoto(Aluno aluno, IFormFile formeFile)
        {
            try
            {
                Stream stream = formeFile.OpenReadStream();
                MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                ms.TryGetBuffer(out ArraySegment<byte> foto);
                //ms.Seek(0, SeekOrigin.Begin);
                stream.Close();
                aluno.Foto = foto.Array;
                await _repository.Update(aluno);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no metodo AssociaFoto " + ex.Message);
            }
        }
    }
}
