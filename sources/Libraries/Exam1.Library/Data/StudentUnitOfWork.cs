using System;

using Exam1.Library.Data.Entities;

namespace Exam1.Library.Data
{
	public class StudentUnitOfWork
		: UnitOfWorkBase<Student, Guid, SchoolContext>
	{
		public StudentRepository Students { get; private set; }

		public CourseRepository Courses { get; private set; }

		public StudentUnitOfWork(string connectionString, string migartionAssemblyName)
			: base(connectionString, migartionAssemblyName)
		{
			Students = (StudentRepository)Activator.CreateInstance(typeof(StudentRepository), _Context);

			Courses = (CourseRepository)Activator.CreateInstance(typeof(CourseRepository), _Context);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			Students.Dispose();
			Courses.Dispose();
		}

	}
}
