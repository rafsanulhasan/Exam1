using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Exam1.Library.Data.Core.Entities;

namespace Exam1.Library.Data.Entities
{
	public class Course
		: EntityBase<Guid>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public double Price { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		public ICollection<Topic> Topics { get; set; } = new List<Topic>();

		public virtual ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
	}
}
