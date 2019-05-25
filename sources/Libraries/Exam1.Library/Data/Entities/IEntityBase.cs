namespace Exam1.Library.Data.Core.Entities
{
	public interface IEntityBase<T>
	{
		T Id { get; set; }
	}
}