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
