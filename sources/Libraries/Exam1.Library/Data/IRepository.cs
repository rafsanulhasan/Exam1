using System;
using System.Linq;
using System.Linq.Expressions;

using Exam1.Library.Data.Core.Entities;

namespace Exam1.Library.Data
{
	public interface IRepository<TEntity, TKey>
		: IDisposable
		where TEntity : EntityBase<TKey>
	{
		void Create(TEntity entity);
		IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> filter = null);
		void Update(TEntity entity);
		void Delete(TEntity entity);
	}

}
