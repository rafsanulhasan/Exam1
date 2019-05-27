using Exam1.Library.Services;
using Exam1.Library.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Exam1.Web.Controllers
{
	public class StudentController : Controller
	{
		private StudentService _service;

		public StudentController(StudentService service)
		{
			_service = service;
		}

		/// <summary>
		/// /Student
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			var vm = new StudentViewModel();
			vm.SetService(_service);
			vm.Read(pageIndex: 3, itemCount: 5);
			return View(vm);
		}
	}
}