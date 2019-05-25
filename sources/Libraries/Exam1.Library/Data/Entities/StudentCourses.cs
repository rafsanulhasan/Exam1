using System;

namespace Exam1.Library.Data.Entities
{
	public class StudentCourses
	{
		public Guid StudentId { get; set; }
		public Guid CourseId { get; set; }

		public virtual Student Student { get; set; }
		public virtual Course Course { get; set; }
	}
}
