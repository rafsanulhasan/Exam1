using System;

using Exam1.Library.Data.Entities;

namespace Exam1.Library.Data
{
	public class StudentRepository
		: RepositoryBase<Student, Guid, SchoolContext>
	{
		public StudentRepository(SchoolContext context)
			: base(context)
		{
		}
	}
}
