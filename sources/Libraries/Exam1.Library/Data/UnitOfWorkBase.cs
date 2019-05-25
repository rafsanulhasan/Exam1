using System;

using Exam1.Library.Data.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Exam1.Library.Data
{
	public abstract class UnitOfWorkBase<TEntity, TKey, TContext>
		: IDisposable
		where TEntity : EntityBase<TKey>, IEntityBase<TKey>
		where TContext : DbContext
	{
		protected TContext _Context;

		protected UnitOfWorkBase(string connectionString, string migartionAssemblyName)
		{
			_Context = (TContext)Activator.CreateInstance(typeof(TContext), connectionString, migartionAssemblyName);
		}

		public void Save()
		{
			_Context.SaveChanges();
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					_Context.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		~UnitOfWorkBase()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(false);
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
