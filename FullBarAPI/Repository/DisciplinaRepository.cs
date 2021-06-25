using FullBarAPI.Models;
using FullBarAPI.Models.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Repository
{
    public class DisciplinaRepository : IRepository<Disciplina>
    {

        private ISession _session;

        public DisciplinaRepository(ISession session)
        {
            _session = session;
        }

        public async Task Add(Disciplina item)
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
                throw new Exception("Erro ao Salvar Disciplina " + ex);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Disciplina> FindById(int id) => await _session.GetAsync<Disciplina>(id);

        public Task<IEnumerable<Disciplina>> FindAll() => Task.FromResult((IEnumerable<Disciplina>)_session.Query<Disciplina>().ToList());


        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Disciplina item)
        {
            throw new NotImplementedException();
        }
    }
}
