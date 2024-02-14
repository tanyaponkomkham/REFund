using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REFund.Data;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using REFund.Class;

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
			var sql = await _context.EmpInfo.Where(s => s.empID == username && s.password == password).Select(s => new { s.empID, s.eng_fullname, s.start_work, s.Position_Name, s.Dept_Name, s.StaffLevel_Name ,s.domain_name}).FirstOrDefaultAsync();
			string date = sql.start_work.HasValue ? sql.start_work.Value.ToString("dd/MM/yyyy") : string.Empty;
			try
			{
				if (sql != null)
				{
					clsAuthenticate clsAuth = new clsAuthenticate();
					HttpContext.Session.SetString(clsAuth.SessionUserId, sql.empID);
					HttpContext.Session.SetString(clsAuth.SessionName, sql.eng_fullname);
					HttpContext.Session.SetString(clsAuth.SessionStartWork, date);
					HttpContext.Session.SetString(clsAuth.SessionPositionName, sql.Position_Name);
					HttpContext.Session.SetString(clsAuth.SessionDeptName, sql.Dept_Name);
					HttpContext.Session.SetString(clsAuth.SessionStaffLevel, sql.StaffLevel_Name);
					HttpContext.Session.SetString(clsAuth.SessionDomain, sql.domain_name);
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
					clsAuthenticate clsAuth  = new clsAuthenticate();

					var getEmpId = _context.EmpInfo.Where(s => s.domain_name == domain.Trim()).Select(s => new { s.empID,s.eng_fullname,s.start_work,s.Position_Name,s.Dept_Name, s.StaffLevel_Name, s.domain_name }).FirstOrDefault();
					string date = getEmpId.start_work.HasValue ? getEmpId.start_work.Value.ToString("dd/MM/yyyy") : string.Empty;


					HttpContext.Session.SetString(clsAuth.SessionUserId, getEmpId.empID);
					HttpContext.Session.SetString(clsAuth.SessionName, getEmpId.eng_fullname);
					HttpContext.Session.SetString(clsAuth.SessionStartWork, date); 
					HttpContext.Session.SetString(clsAuth.SessionPositionName, getEmpId.Position_Name);
					HttpContext.Session.SetString(clsAuth.SessionDeptName, getEmpId.Dept_Name);
					HttpContext.Session.SetString(clsAuth.SessionStaffLevel, getEmpId.StaffLevel_Name);
					HttpContext.Session.SetString(clsAuth.SessionDomain, getEmpId.domain_name);
					return StatusCode(200, getEmpId);
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

			string initShortDomainName = "sat";

			using (PrincipalContext context = new PrincipalContext(ContextType.Domain, initShortDomainName, domain,password))
			{
				return context.ValidateCredentials(domain, password);
			}
		}

	}
}
