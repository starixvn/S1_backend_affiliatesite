using AffiliateSite.Framework;
using System.Data.Common;

namespace AffiliateSite.WebApi.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbConnection _connection;
        private DbTransaction _transaction;
        public UnitOfWork(DbConnection connection)
        {
            _connection = connection;
        }
        public DbConnection Connection => _connection;
        public DbTransaction Transaction => _transaction;
        public async Task BeginTransactionAsync() 
        {
            await _connection.OpenAsync();
            _transaction = await _connection.BeginTransactionAsync();
        } 

        public async Task CommitAsync() => await _transaction.CommitAsync();

        public async Task RollbackAsync() => await _transaction.RollbackAsync();
        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            _transaction = null;
        }
    }
}
