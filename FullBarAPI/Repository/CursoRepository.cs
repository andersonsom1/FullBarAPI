using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Repository
{
    public class CursoRepository : IRepository<Curso>
    {
        private ISession _session;

        public CursoRepository(ISession session)
        {
            _session = session;
        }

        public async Task Add(Curso item)
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
                throw new Exception("Erro ao Salvar Curso " + ex);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Curso> FindById(int id) => await _session.GetAsync<Curso>(id);


        public Task<IEnumerable<Curso>> FindAll() => Task.FromResult((IEnumerable<Curso>)_session.Query<Curso>().ToList());

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Curso item)
        {
            throw new NotImplementedException();
        }
    }
}
