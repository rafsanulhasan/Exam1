using System;

using Exam1.Library.Data.Entities;

namespace Exam1.Library.Data
{
	public class CourseUnitOfWork
		: UnitOfWorkBase<Course, Guid, SchoolContext, CourseRepository>
	{
		public TopicRepository Topics { get; private set; }

		public CourseUnitOfWork(string connectionString, string migartionAssemblyName)
			: base(connectionString, migartionAssemblyName)
		{
			Topics = (TopicRepository)Activator.CreateInstance(typeof(TopicRepository), _Context);
		}
	}
}
