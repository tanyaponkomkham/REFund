using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REFund.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{

			return View();
		}
		public IActionResult Menu()
		{
			return View();
		}
		public IActionResult _RequestsContent()
		{
			return PartialView("_RequestsContent");
		}
		
		public IActionResult AllRequest()
		{
			return PartialView("AllRequest");
		}
		public IActionResult MyRequest()
		{
			return PartialView("MyRequest");
		}
		public IActionResult Requests()
		{
			return PartialView("Requests");
		}
		public IActionResult Document()
		{
			return PartialView("Document");
		}
		public IActionResult Return()
		{
			return PartialView("Return");
		}
		public IActionResult Disapprove()
		{
			return PartialView("Disapprove");
		}
		public IActionResult HR_Review()
		{
			return PartialView("HR_Review");
		}
		public IActionResult Manager_Review()
		{
			return PartialView("Manager_Review");
		}
		public IActionResult CFO_Review()
		{
			return PartialView("CFO_Review");
		}
		public IActionResult HR_Manager_Review()
		{
			return PartialView("HR_Manager_Review");
		}
		public IActionResult Completed()
		{
			return PartialView("Completed");
		}
		public IActionResult Category()
		{
			return PartialView("Category");
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
