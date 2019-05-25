using System;

using Exam1.Library.Data.Entities;

namespace Exam1.Library.Data
{
	public class StudentUnitOfWork
		: UnitOfWorkBase<Student, Guid, SchoolContext, StudentRepository>
	{
		public CourseRepository Courses { get; private set; }

		public StudentUnitOfWork(string connectionString, string migartionAssemblyName)
			: base(connectionString, migartionAssemblyName)
		{
			Courses = (CourseRepository)Activator.CreateInstance(typeof(CourseRepository), _Context);
		}
	}
}
