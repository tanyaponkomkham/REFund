using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using REFund.Data;
using REFund.Models;
using REFund.Models.Views;

namespace REFund.Controllers
{
	public class SharedController : Controller
	{
        private readonly CoreContext _context;

        public SharedController(CoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> _Layout()
        {
            Request request = new Request();
            var context = new PrincipalContext(ContextType.Domain);
            var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
            //เช็คถ้าโดเมนตรงกับที่มีอยู่ใน workflow ให้ get Step มา
            var getStep = await _context.Workflow.Where(s => s.ActionDomain == principal.SamAccountName).Select(s => s.Step).FirstOrDefaultAsync();
            if (getStep != null)
            {
                //เช็คถ้าโดเมนตรง  เอาStep มาลบ1เพื่อเรียก Request ที่มีStatus นั้นมาๆ
                request = await _context.Request.Include(s => s.Category).Include(s => s.Workflow.Status).Where(s => s.WorkflowID == getStep - 1).Select(s => s).FirstOrDefaultAsync();
            }


            //เพื่อเรียกข้อมูลสำหรับคนมีตำแหน่งเป็นManager ให้คนนั้นมีสิทธิ์
            var ManagerDomain = await _context.EmpInfo
            .Join(_context.Request.Include(s => s.Category).Include(s => s.Workflow.Status), e => EF.Functions.Collate(e.empID, "Thai_CS_AI"), r => EF.Functions.Collate(r.EmployeeId, "Thai_CS_AI"), (e, r) => new { EmpInfo = e, Request = r })
            .Where(joined => joined.Request.WorkflowID == 2 && EF.Functions.Collate(joined.EmpInfo.ManagerDomainId, "Thai_CS_AI") == principal.SamAccountName)
            .Select(joined => joined.Request).ToListAsync();

            ViewBag.Requester = await _context.EmpInfo.FirstOrDefaultAsync(s => s.domain_name == principal.SamAccountName);
            ViewBag.Step = getStep;
            //Union ระหว่าง getWorkflowกับManagerDomain
            var requests = (request != null
            ? ManagerDomain.Union(new List<Request> { request })
            : ManagerDomain).ToList();


			//var getEmpId = await _context.EmpInfo.Where(s => s.domain_name == principal.SamAccountName).Select(s => s.empID).FirstOrDefaultAsync();
			//ViewBag.countAllRequest = _context.Request.Count();
			//ViewBag.countMyRequest = _context.Request.Count(s => s.EmployeeId == getEmpId).ToString();
			//ViewBag.countMyApprove = requests.Count();

			return View(requests);
        }
    }
}
