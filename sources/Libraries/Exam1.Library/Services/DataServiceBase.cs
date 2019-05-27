using System;
using System.Linq;
using System.Linq.Expressions;

using Exam1.Core;
using Exam1.Library.Data;
using Exam1.Library.Data.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Exam1.Library.Services
{
	public abstract class DataServiceBase<TUnitOfWork, TEntity, TKey, TContext, TRepository>
		: IService
		where TEntity : EntityBase<TKey>
		where TContext : DbContext
		where TRepository : RepositoryBase<TEntity, TKey, TContext>, IRepository<TEntity, TKey>
		where TUnitOfWork : UnitOfWorkBase<TEntity, TKey, TContext>

	{
		protected TUnitOfWork _Uow;
		protected DataServiceBase(TUnitOfWork uow)
		{
			_Uow = uow;
		}

		public abstract IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> filter = null);
	}
}
