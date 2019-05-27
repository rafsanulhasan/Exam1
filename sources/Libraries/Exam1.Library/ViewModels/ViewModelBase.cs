using System;
using System.Linq.Expressions;

using Exam1.Library.Data;
using Exam1.Library.Data.Core.Entities;
using Exam1.Library.Services;

using Microsoft.EntityFrameworkCore;

namespace Exam1.Library.ViewModels
{
	public abstract class ViewModelBase<TService, TUnitOfWork, TEntity, TKey, TContext, TRepository>
		where TEntity : EntityBase<TKey>
		where TContext : DbContext
		where TRepository : RepositoryBase<TEntity, TKey, TContext>, IRepository<TEntity, TKey>
		where TUnitOfWork : UnitOfWorkBase<TEntity, TKey, TContext>
		where TService : DataServiceBase<TUnitOfWork, TEntity, TKey, TContext, TRepository>
	{
		protected TService _Service;

		public void SetService(TService service)
		{
			_Service = service;
		}

		public abstract void Read(Expression<Func<TEntity, bool>> filter = null, int pageIndex = 1, int pageCount = 1);
	}
}
