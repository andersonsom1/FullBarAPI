using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Repository
{
    public class AlunoRepository : IRepository<Aluno>
    {
        private ISession _session;

        public AlunoRepository(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Commit;
        }

        public async Task Add(Aluno item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Erro ao Salvar Aluno " + ex);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Aluno> FindById(int id) => await _session.GetAsync<Aluno>(id);

        public Task<IEnumerable<Aluno>> FindAll(Aluno aluno = null) => Task.FromResult((IEnumerable<Aluno>)_session.Query<Aluno>().ToList());

        //public Task<IEnumerable<AlunoCurso>> FindAllAlunoCurso() => Task.FromResult((IEnumerable<AlunoCurso>)_session.Query<AlunoCurso>().ToList());

        public async Task Remove(int id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                Aluno aluno = await _session.GetAsync<Aluno>(id);
                await _session.DeleteAsync(aluno);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Erro ao remover Aluno " + ex);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task Update(Aluno item)
        {

            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();

                await _session.MergeAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Erro ao update Aluno " + ex);
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }
}
