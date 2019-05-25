using System;

using Exam1.Library.Data.Entities;

namespace Exam1.Library.Data
{
	public class CourseUnitOfWork
		: UnitOfWorkBase<Course, Guid, SchoolContext>
	{
		public CourseRepository Courses { get; private set; }

		public TopicRepository Topics { get; private set; }

		public CourseUnitOfWork(string connectionString, string migartionAssemblyName)
			: base(connectionString, migartionAssemblyName)
		{
			Courses = (CourseRepository)Activator.CreateInstance(typeof(CourseRepository), _Context);

			Topics = (TopicRepository)Activator.CreateInstance(typeof(TopicRepository), _Context);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			Courses.Dispose();
			Topics.Dispose();
		}
	}
}
