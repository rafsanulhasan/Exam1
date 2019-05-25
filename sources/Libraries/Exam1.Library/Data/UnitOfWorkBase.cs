using System;

using Exam1.Library.Data.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Exam1.Library.Data
{
	public abstract class UnitOfWorkBase<TEntity, TKey, TContext, TRepository>
		: IDisposable
		where TEntity : EntityBase<TKey>, IEntityBase<TKey>
		where TContext : DbContext
		where TRepository : RepositoryBase<TEntity, TKey, TContext>, IRepository<TEntity, TKey>
	{
		protected TContext _Context;
		public TRepository Repository { get; protected set; }

		protected UnitOfWorkBase(string connectionString, string migartionAssemblyName)
		{
			_Context = (TContext)Activator.CreateInstance(typeof(TContext), connectionString, migartionAssemblyName);
			Repository = (TRepository)Activator.CreateInstance(typeof(TRepository), _Context);
		}

		public void Dispose()
		{
			_Context.Dispose();
			Repository.Dispose();
		}

		public void Save()
		{
			_Context.SaveChanges();
		}
	}
}
