using System;
using System.Linq;
using System.Linq.Expressions;

using Exam1.Core;
using Exam1.Library.Data;
using Exam1.Library.Data.Entities;

namespace Exam1.Library.Services
{
	public class StudentService
		: DataServiceBase<StudentUnitOfWork, Student, Guid, SchoolContext, StudentRepository>, IService
	{
		public StudentService(StudentUnitOfWork uow)
			: base(uow)
		{
		}

		public override IQueryable<Student> Read(Expression<Func<Student, bool>> filter = null)
		{
			return _Uow.Students.Read(filter);
		}
	}
}
