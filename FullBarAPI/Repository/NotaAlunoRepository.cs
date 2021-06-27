using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Repository
{
    public class NotaAlunoRepository : IRepository<NotaAluno>
    {
        private ISession _session;

        public NotaAlunoRepository(ISession session)
        {
            _session = session;
        }

        public async Task Add(NotaAluno item)
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
                throw new Exception("Erro ao Salvar NotaAluno " + ex);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<NotaAluno> FindById(int id) => await _session.GetAsync<NotaAluno>(id);

        public Task<IEnumerable<NotaAluno>> FindAll(NotaAluno notaAluno = null)
        {
            if (notaAluno != null)
            return Task.FromResult((IEnumerable<NotaAluno>)_session.QueryOver<NotaAluno>().Where(w =>
            w.IdDisciplina == notaAluno.IdDisciplina && 
            w.IdAluno == notaAluno.IdAluno).List());
            //{
            //    var teste = _session.QueryOver<NotaAluno>().Where(w =>
            //    w.IdDisciplina == notaAluno.IdDisciplina).;

            //    return null;
            //}
            else
                return Task.FromResult((IEnumerable<NotaAluno>)_session.Query<NotaAluno>().ToList());
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(NotaAluno item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(item);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Erro ao update NotaAluno " + ex);
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }
}
