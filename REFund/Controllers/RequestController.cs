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
    public class RequestController : Controller
    {
        private readonly CoreContext _context;

        public RequestController(CoreContext context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {

            var request = await _context.Request.Include(s => s.Category).Include(s => s.Workflow.Status).ToListAsync();
            
            return View(request);
        }

        public async Task<IActionResult> MyRequest()
        {

            var context = new PrincipalContext(ContextType.Domain);
            var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);

            var getEmpId = await _context.EmpInfo.Where(s => s.domain_name == principal.SamAccountName).Select(s => s.empID).FirstOrDefaultAsync();

            var request = await _context.Request.Include(s => s.Category).Include(s => s.Workflow.Status).Where(s => s.EmployeeId == getEmpId).ToListAsync();

            return View(request);
        }
        //public async Task<IActionResult> TableMyRequest(string empId)
        //{
        //    try
        //    {
        //        var getTblMyRequest = await (
        //            from req in _context.Request
        //            join c in _context.Category on req.CategoryID equals c.ID
        //            where req.EmployeeId == empId
        //            select new
        //            {
        //                Id = req.Id.ToString("N").Substring(0, 10),
        //                empID = req.EmployeeId,
        //                IdRequest = req.Id,
        //                c.CategoryName,
        //                req.CreateBy,
        //                CreateAt = req.CreateAt.Date, // Use Date property to get only the date part
        //                req.WorkflowID
        //            }
        //        )
        //        .ToListAsync();

        //        return Ok(getTblMyRequest);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}



        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public async Task<IActionResult> Create()
        {
            var context = new PrincipalContext(ContextType.Domain);
            var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);

            ViewBag.Requester = await _context.EmpInfo.FirstOrDefaultAsync(s => s.domain_name == principal.SamAccountName);
            ViewBag.Category = new SelectList(CategoryDropDownList(), "Key", "Value");

            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Request request, List<IFormFile> attachments)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    request.Id = Guid.NewGuid();
                    _context.Add(request);
                    await _context.SaveChangesAsync();

                    foreach (var file in attachments)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        request.Attachments.Add(new Attachment
                        {
                            RequestId = request.Id,
                            Content = ms.ToArray(),
                            ContentName = file.FileName,
                            ContentMimeType = file.ContentType,

                        });
                    }
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    return StatusCode(200, request.Id);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            return StatusCode(500, request.Id);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var context = new PrincipalContext(ContextType.Domain);
            var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);


            if (id == null)
            {
                return NotFound();
            }
            RequestsView requestsView = new RequestsView();

            var request = await _context.Request.FindAsync(id);

            requestsView.Id = request.Id;
            requestsView.EmployeeId = request.EmployeeId;
            requestsView.Quota = request.Quota;
            requestsView.Used = request.Used;
            requestsView.Remain = request.Remain;
            requestsView.Amount = request.Amount;
            requestsView.Detail = request.Detail;
            requestsView.HRDomainReview = await _context.Workflow.Where(s => s.Step == 2).Select(s => s.ActionDomain).FirstOrDefaultAsync();
            requestsView.ManagerDomainApprove = await _context.EmpInfo.Where(s => s.empID == request.EmployeeId).Select(s => s.ManagerDomainId).FirstOrDefaultAsync();
            requestsView.HRManagerDomainApprove = await _context.Workflow.Where(s => s.Step == 4).Select(s => s.ActionDomain).FirstOrDefaultAsync();
            requestsView.CFODomainApprove = await _context.Workflow.Where(s => s.Step == 5).Select(s => s.ActionDomain).FirstOrDefaultAsync();
            requestsView.WorkflowID = request.WorkflowID;
            ViewBag.Requester = await _context.EmpInfo.FirstOrDefaultAsync(s => s.empID == request.EmployeeId);
            ViewBag.Category = new SelectList(CategoryDropDownList(), "Key", "Value", request.CategoryID);
            ViewBag.Whom = new SelectList(WhomDropDownListForEdit(request.CategoryID), "Key", "Value", request.WhomID);
            //var whomName = await _context.Request
            // .Where(r => r.WhomID == request.WhomID && r.Id == request.Id)
            // .Join(
            //     _context.Whom,
            //     r => r.WhomID,
            //     w => w.ID,
            //     (r, w) => w.WhomName
            // )
            // .ToListAsync();

            //ViewBag.Whom = whomName ;


            //ViewBag.Whom = new SelectList(GetWhomName(request.WhomID), "Key", "Value");
            return View(requestsView);
        }


        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Request request)
        {

            var report = await _context.Request.FindAsync(request.Id);
            var reqHistory = request.Historys.ToList();
            if (reqHistory.Count != 0)
            {
                report.Historys.Add(new History
                {

                    EmployeeId = reqHistory[0].EmployeeId,
                    Detail = reqHistory[0].Detail,
                    Quota = reqHistory[0].Quota,
                    Used = reqHistory[0].Used,
                    Remain = reqHistory[0].Remain,
                    Amount = reqHistory[0].Amount,
                    Comment = reqHistory[0].Comment,
                    CreateBy = reqHistory[0].CreateBy,
                    CreateAt = reqHistory[0].CreateAt,
                    UpdateBy = reqHistory[0].UpdateBy,
                    UpdateAt = reqHistory[0].UpdateAt,
                    ConfirmDate = reqHistory[0].ConfirmDate,
                    WorkflowID = reqHistory[0].WorkflowID,
                    CategoryID = reqHistory[0].CategoryID,
                    WhomID = reqHistory[0].WhomID
                });

                report.Detail = request.Detail;
                report.Quota = request.Quota;
                report.Used = request.Used;
                report.Remain = request.Remain;
                report.Amount = request.Amount;
                report.UpdateBy = request.UpdateBy;
                report.UpdateAt = request.UpdateAt;
                report.WorkflowID = request.WorkflowID;
                report.CategoryID = request.CategoryID;
                report.WhomID = request.WhomID;
            }
            else
            {
                report.Detail = request.Detail;
                report.Quota = request.Quota;
                report.Used = request.Used;
                report.Remain = request.Remain;
                report.Amount = request.Amount;
                report.UpdateBy = request.UpdateBy;
                report.UpdateAt = request.UpdateAt;
                report.WorkflowID = request.WorkflowID;
                report.CategoryID = request.CategoryID;
                report.WhomID = request.WhomID;
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok(); // หรือในที่นี้คุณสามารถคืน Ok หรือตามที่เหมาะสม
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var request = await _context.Request.FindAsync(id);
            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> GetQuotaTitle(int categoryID, string empId, int whomID)
        {
            try
            {
                var getQuotaPrice = await _context.CategoryDetail.Where(s => s.CategoryID == categoryID && s.WhomID == whomID).Select(s => s.QuotaPrice).FirstOrDefaultAsync();

                var getUsePrice = await _context.Request.Where(s => s.EmployeeId == empId && s.Workflow.ID == (int)IDStatus.Completed).Select(s => s.Amount).ToListAsync();

                int usedPrice = 0;

				foreach (var item in getUsePrice)
				{
                    usedPrice = usedPrice + item;
                }

                var remainPrice = getQuotaPrice.Value - usedPrice;
                //var getUsePrice = _context.Request.Where(s => )

                return new ObjectResult(new { QuotaPrice = getQuotaPrice.Value, UsedPrice = usedPrice, RemainPrice = remainPrice });


            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetDocumentDetail(int categoryID, int whomID)
        {
            try
            {
                //var getCategory = await _context.DocumentDetail.Where(s => s.CategoryID == categoryID).ToListAsync();

                var getCategory = (from l in _context.DocumentDetail
                                    join q in _context.Document on l.DocumentID equals q.ID
                                    where l.CategoryID == categoryID && l.WhomID == whomID
                                    select new
                                    {
                                        DocumentID = q.ID,
                                        DocumentName = q.DocumentName
                                    }
                                   ).Distinct()
                                    .OrderBy(x => x.DocumentID)  // เพิ่มนี้เพื่อเรียงลำดับตาม DocumentID
                                    .ToList();
                //foreach (var item in getCategory1)
                //{
                //    Console.WriteLine($"DocumentID: {item.DocumentID}, DocumentName: {item.DocumentName}");
                //}
                //// Use ToListAsync() to asynchronously retrieve the list
                ////return new ObjectResult(new { QuotaPrice = getQuotaPrice.Value, UsedPrice = usedPrice, RemainPrice = remainPrice });
                ////return StatusCode(500, true);
                //var jsonOptions = new JsonSerializerOptions
                //{
                //    ReferenceHandler = ReferenceHandler.Preserve,
                //    // เพิ่มตัวเลือกอื่นๆ ตามที่ต้องการ
                //};

                //var serializedData = JsonSerializer.Serialize(getCategory1, jsonOptions);

                //return Ok(serializedData);
                return StatusCode(200, getCategory);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
			
		}

        [HttpPost]
        public async Task<IActionResult> GetDocumentDetailForEdit(int categoryID, int whomID, Guid requestID)
        {
            try
            {
                //var getCategory = await _context.DocumentDetail.Where(s => s.CategoryID == categoryID).ToListAsync();

                var getCategory = (from l in _context.RequestDocumentDetail
                                   join q in _context.Document on l.DocumentID equals q.ID
                                   join r in _context.Request on l.RequestID equals r.Id
                                   where l.RequestID == requestID
                                   select new
                                   {
                                       DocumentID = q.ID,
                                       DocumentName = q.DocumentName
                                   }
                                   ).Distinct()
                                    .OrderBy(x => x.DocumentID)  // เพิ่มนี้เพื่อเรียงลำดับตาม DocumentID
                                    .ToList();

                return StatusCode(200, getCategory);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }


        private IDictionary<int, string> CategoryDropDownList()
        {
            IDictionary<int, string> dict = new Dictionary<int, string>();

            var getCategory = _context.Category.Where(s => s.Status == "1").ToList();

            if (getCategory.Count > 0)
			{
                foreach (var item in getCategory)
                {
                    dict.Add(item.ID, item.CategoryName);
                }
            }

            return dict;
            //IDictionary<string, string> dict = new Dictionary<string, string>
            //{
            //    { "Active", "Active" },
            //    { "Obsoleted", "Obsoleted" }
            //};

           
        }
        private IDictionary<int, string> WhomDropDownListForEdit(int categoryID)
        {
            IDictionary<int, string> dict = new Dictionary<int, string>();

            var getWhom = _context.CategoryDetail.Where(s => s.CategoryID == categoryID).Select(s => s.Whom).ToList();
            //var getWhom = _context.Whom.Where(s => s.Status == "1" ).ToList();

            if (getWhom.Count > 0)
            {
                foreach (var item in getWhom)
                {
                    dict.Add(item.ID, item.WhomName);
                }
            }

            return dict;



        }
        [HttpPost]
        public async Task<IActionResult> WhomDropDownList(int categoryID)
        {
            try
            {
                //var getCategory = await _context.DocumentDetail.Where(s => s.CategoryID == categoryID).ToListAsync();

                var getWhom = (from l in _context.CategoryDetail
                               join q in _context.Whom on l.WhomID equals q.ID
                               where l.CategoryID == categoryID
                               select new
                               {
                                   WhomID = q.ID,
                                   WhomName = q.WhomName
                               }
                                   ).Distinct()
                                    .OrderBy(x => x.WhomID)
                                    .ToList();

                return StatusCode(200, getWhom);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        [HttpPost]
		public async Task<IActionResult> GetCategoryName(int Categoryid)
		{
			try
			{

				var getMyRequest = (from l in _context.Category
									where l.ID == Categoryid
									select l.CategoryName
							   ).ToList();

				return StatusCode(200, getMyRequest);
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}

		}
        public async Task<IActionResult> GetCategorName(int Categoryid)
        {
            try
            {

                var getMyRequest = (from l in _context.Category
                                    where l.ID == Categoryid
                                    select l.CategoryName
                               ).ToList();

                return StatusCode(200, getMyRequest);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }


        private bool RequestExists(Guid id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}
