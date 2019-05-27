using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

using Exam1.Library.Data;
using Exam1.Library.Data.Entities;
using Exam1.Library.Services;

namespace Exam1.Library.ViewModels
{

	public class StudentViewModel
		: ViewModelBase<StudentService, StudentUnitOfWork, Student, Guid, SchoolContext, StudentRepository>
	{
		[Required]
		public string Name { get; set; }

		public override void Read(Expression<Func<Student, bool>> filter = null, int pageIndex = 1, int itemCount = 1)
		{
			var studentQuery = _Service
									.Read(filter)
									.Skip((pageIndex - 1) * itemCount)
									.Take(itemCount);

			Name = studentQuery.First().Name;
		}
	}
}
