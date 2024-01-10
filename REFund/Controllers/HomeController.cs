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
		public IActionResult Index1()
		{

			return View();
		}
		public IActionResult Menu()
		{
			return View();
		}
		public IActionResult _RequestsContent()
		{
			return View();
		}
		
		public IActionResult AllRequest()
		{
			return View();
		}
		public IActionResult MyRequest()
		{
			return View();
		}
		public IActionResult Requests()
		{
			return View();
		}
		public IActionResult Document()
		{
			return View();
		}
		public IActionResult Return()
		{
			return View();
		}
		public IActionResult Disapprove()
		{
			return View();
		}
		public IActionResult HR_Review()
		{
			return View();
		}
		public IActionResult Manager_Review()
		{
			return View();
		}
		public IActionResult CFO_Review()
		{
			return View();
		}
		public IActionResult HR_Manager_Review()
		{
			return View();
		}
		public IActionResult Completed()
		{
			return View();
		}
		public IActionResult Category()
		{
			return View();
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
