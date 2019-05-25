using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam1.Library.Data.Core.Entities
{
	public abstract class EntityBase<T>
		: IEntityBase<T>
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public T Id { get; set; }
	}
}
