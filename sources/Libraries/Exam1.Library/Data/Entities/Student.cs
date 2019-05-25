using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Exam1.Library.Data.Core.Entities;

namespace Exam1.Library.Data.Entities
{
	public class Student
		: EntityBase<Guid>
	{
		[Required]
		public string Name { get; set; }
		public virtual ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
	}
}
