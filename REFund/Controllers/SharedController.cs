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
            var context = new PrincipalContext(ContextType.Domain);
            var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
            //เช็คถ้าโดเมนตรงกับที่มีอยู่ใน workflow ให้ get Step มา
            var  getStep = await _context.Workflow.Where(s => s.ActionDomain == principal.SamAccountName).Select(s => s.Step).FirstOrDefaultAsync();

            //เช็คถ้าโดเมนตรง  เอาStep มาลบ1เพื่อเรียก Request ที่มีStatus นั้นมาๆ
            var getWorkflow = await _context.Request.Where( s => s.WorkflowID == getStep-1 ).Select(s => s).FirstOrDefaultAsync();

            //เพื่อเรียกข้อมูลสำหรับคนมีตำแหน่งเป็นManager ให้คนนั้นมีสิทธิ์
            var ManagerDomain = await _context.EmpInfo.Join(_context.Request, e => e.empID, r => r.EmployeeId, (e, r) => new { EmpInfo = e, Request = r }).Where(joined => joined.Request.WorkflowID == 2 && joined.EmpInfo.ManagerDomainId == principal.SamAccountName).Select(joined => joined.Request).ToListAsync();

            //Union ระหว่าง getWorkflowกับManagerDomain
            ViewBag.combinedResults = getWorkflow != null
            ? ManagerDomain.Union(new List<Request> { getWorkflow })
            : ManagerDomain;

            return View();
        }
    }
}
