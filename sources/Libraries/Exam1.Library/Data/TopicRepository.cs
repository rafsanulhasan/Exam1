using System;

using Exam1.Library.Data.Entities;

namespace Exam1.Library.Data
{
	public class TopicRepository
		: RepositoryBase<Topic, Guid, SchoolContext>
	{
		public TopicRepository(SchoolContext context)
			: base(context)
		{
		}
	}
}
