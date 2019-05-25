using System;

using Exam1.Library.Data.Entities;

namespace Exam1.Library.Data
{
	public class CourseRepository
		: RepositoryBase<Course, Guid, SchoolContext>
	{
		public CourseRepository(SchoolContext context)
			: base(context)
		{
		}
	}
}
