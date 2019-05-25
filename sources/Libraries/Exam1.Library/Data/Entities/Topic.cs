using System;
using System.ComponentModel.DataAnnotations;

using Exam1.Library.Data.Core.Entities;

namespace Exam1.Library.Data.Entities
{
	public class Topic
		: EntityBase<Guid>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		public virtual Course Course { get; set; }
		public Guid CourseId { get; set; }
	}
}