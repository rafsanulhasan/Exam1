using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Exam1.Core;
using Exam1.Library.Data;
using Exam1.Library.Data.Entities;
using Exam1.Library.ViewModels;

using Microsoft.EntityFrameworkCore;

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

		public IQueryable<Student> GetStudentsCompletedSpecificTopic()
		{
			var courseId = Guid.Empty;
			var students = Read().Include(s => s.StudentCourses);
			ICollection<StudentViewModel> result = new List<StudentViewModel>();
			foreach (var student in students)
			{
				var studentCompletedCourses = student
								.StudentCourses
								.Where(sc => sc.Course.Id == courseId)
								.Select(sc => sc.Student);

				foreach (var s in studentCompletedCourses)
				{
					result.Add(AutoMapper.Map<StudentViewModel>(s));
				}
			}
			return result.AsQueryable();
		}
	}
}
