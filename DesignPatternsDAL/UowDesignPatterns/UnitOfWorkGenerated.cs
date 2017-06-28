
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsDAL;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using DesignPatternsDAL.Uow;

namespace DesignPatternsDAL.UowDesignPatterns
{
    public class UnitOfWork : IUnitOfWorkAsync
    {
        private DesignPatternsContext _dataContext = new DesignPatternsContext();
        protected ObjectContext _objectContext;
        protected DbTransaction _transaction;

        #region Concrete repositories

		private GenericRepository<Role> _roleRepository;
		public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                {
                    this._roleRepository = new GenericRepository<Role>(_dataContext);
                }
                return _roleRepository;
            }
        }

		private GenericRepository<User> _userRepository;
		public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(_dataContext);
                }
                return _userRepository;
            }
        }


        #endregion

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                    {
                        _objectContext.Connection.Close();
                    }

					if (_dataContext != null)
                    {
                        _dataContext.Dispose();
                        _dataContext = null;
                    }
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #region Methods

        #region IUnitOfWorkAsync Members

        public Task<int> SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _dataContext.SaveChangesAsync(cancellationToken);
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public void BeginTransaction(System.Data.IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }
            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public bool IsTransactionOpen
        {
            get { { return (_transaction != null && _transaction.Connection != null); } }
        }

        #endregion

        #endregion
    }
}


