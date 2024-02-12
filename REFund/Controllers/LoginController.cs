using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REFund.Data;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Controllers
{
	public class LoginController : Controller
	{

		private readonly CoreContext _context;

		public LoginController(CoreContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
			var sql = await _context.EmpInfo.Where(s => s.empID == username && s.password == password).FirstOrDefaultAsync();

			try
			{
				if (sql != null)
				{

					return StatusCode(200, username);
				}
				else
				{
					return StatusCode(500, "");
				}
			}
			catch (Exception ex)
			{

				return StatusCode(500, ex.ToString());
			}



		}
		[HttpPost]
		public  IActionResult LoginDomain(string domain, string password)
		{
			try
			{
				if (ValidateCredentials(domain,password))
				{

					return StatusCode(200, domain);
				}
				else
				{
					return StatusCode(500, "");
				}
			}
			catch (Exception ex)
			{

				return StatusCode(500, ex.ToString());
			}
			
		}
		public static bool ValidateCredentials(string domain, string password)
		{
			using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
			{
				return context.ValidateCredentials(domain, password);
			}
		}

	}
}
