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
using REFund.Services;
using REFund.Class;

namespace REFund.Controllers
{
    public class RequestController : Controller
    {
        private readonly CoreContext _context;
        private readonly INotify _notify;

       

        public RequestController(CoreContext context, INotify notify)
        {
            _context = context;
            _notify = notify;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {

            var request =  await _context.Request.Include(s => s.Category).Include(s => s.Workflow.Status).ToListAsync();
            
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> GetCountAllRequest()
        {

                var getCountAllRequest = _context.Request.Count();


            return View(getCountAllRequest);

        }

        [HttpPost]
        public async Task<IActionResult> GetCountMyRequest(string empID)
        {

            var getCountMyRequest = _context.Request.Where(s => s.EmployeeId == empID) .Count();


            return View(getCountMyRequest);

        }

        [HttpPost]
        public async Task<IActionResult> GetCountMyApprove(string empID)
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
            : ManagerDomain).Count();

            return View(requests);


        }
        public async Task<IActionResult> MyRequest(string empID)
        {

            //var context = new PrincipalContext(ContextType.Domain);
            //var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);

            //var getEmpId = await _context.EmpInfo.Where(s => s.domain_name == principal.SamAccountName).Select(s => s.empID).FirstOrDefaultAsync();

            var request = await _context.Request.Include(s => s.Category).Include(s => s.Workflow.Status).Where(s => s.EmployeeId == empID).ToListAsync();

            return View(request);
        }

        public async Task<IActionResult> MyApprove(string domain)
        {
            List<Request> requester = null;
            //Request request = new Request();
            //var context = new PrincipalContext(ContextType.Domain);
            //var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
            //เช็คถ้าโดเมนตรงกับที่มีอยู่ใน workflow ให้ get Step มา
            var getStep = await _context.Workflow.Where(s => s.ActionDomain == domain).Select(s => s.Step).FirstOrDefaultAsync();
            if (getStep != null && getStep != 0)
            {
                //เช็คถ้าโดเมนตรง  เอาStep มาลบ1เพื่อเรียก Request ที่มีStatus นั้นมาๆ
             requester = await _context.Request.Include(s => s.Category).Include(s => s.Workflow.Status).Where(s => s.WorkflowID == getStep - 1).ToListAsync();
			}
			else { 


            //เพื่อเรียกข้อมูลสำหรับคนมีตำแหน่งเป็นManager ให้คนนั้นมีสิทธิ์
            var ManagerDomain = await _context.EmpInfo
            .Join(_context.Request.Include(s => s.Category).Include(s => s.Workflow.Status), e => EF.Functions.Collate(e.empID, "Thai_CS_AI"), r => EF.Functions.Collate(r.EmployeeId, "Thai_CS_AI"), (e, r) => new { EmpInfo = e, Request = r })
            .Where(joined => joined.Request.WorkflowID == 2 && EF.Functions.Collate(joined.EmpInfo.ManagerDomainId, "Thai_CS_AI") == domain)
            .Select(joined => joined.Request).ToListAsync();

            ViewBag.Requester = await _context.EmpInfo.FirstOrDefaultAsync(s => s.domain_name == domain);
            ViewBag.Step = getStep;
            //Union ระหว่าง getWorkflowกับManagerDomain
        
            var requests =  (requester != null
            ? ManagerDomain.Union(requester)
            : ManagerDomain).ToList();
           

            return View(requests);
            }
            return View(requester);
        }


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
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetStaffName(string empID)
        {
            try
            {
                var getQuotaPrice = await _context.EmpInfo    // your starting point - table in the "from" statement
             .Join(_context.StaffLevel, // the source table of the inner join
             post => EF.Functions.Collate(post.stafflevelID, "Thai_CS_AI"),        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
             meta => EF.Functions.Collate(meta.StaffLevel_Code, "Thai_CS_AI"),   // Select the foreign key (the second part of the "on" clause)
             (post, meta) => new { Post = post, Meta = meta }) // selection
             .Where(s => s.Post.empID == empID).Select(s => s.Meta.Price).FirstOrDefaultAsync();

                var getUsePrice = await _context.Request.Where(s => s.EmployeeId == empID && s.Workflow.ID == (int)IDStatus.Completed).Select(s => s.Amount).ToListAsync();

                int usedPrice = 0;

                foreach (var item in getUsePrice)
                {
                    usedPrice = usedPrice + item;
                }

                var remainPrice = getQuotaPrice - usedPrice;

                return new ObjectResult(new { QuotaPrice = getQuotaPrice, UsedPrice = usedPrice, RemainPrice = remainPrice });
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return View();
            //var getUsePrice = _context.Request.Where(s => )
            //return View(getQuotaPrice);


        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetPriceMedical(string empID)
        {
            try
            {
                var getEmp = await _context.EmpInfo.FirstOrDefaultAsync(s => s.empID == empID);

                DateTime today = DateTime.Today;
                int months = today.Month - getEmp.start_work.Value.Month;
                int years = today.Year - getEmp.start_work.Value.Year;

                if (today.Day < getEmp.start_work.Value.Day)
                {
                    months--;
                }

                if (months < 0)
                {
                    years--;
                    months += 12;
                }
                int days = (today - getEmp.start_work.Value.AddMonths((years * 12) + months)).Days;

                var getQuotaPrice = 0;

                if (years < 1)
				{
                    getQuotaPrice = 0;

                }
                else if(years <= 2)
				{
                    getQuotaPrice = 2000;

                } else if (years <= 3)
                {
                    getQuotaPrice = 3000;

                } else if (years > 3)
				{
                    getQuotaPrice = 4000;
                }

                    var getUsePrice = await _context.Request.Where(s => s.EmployeeId == empID && s.Workflow.ID == (int)IDStatus.Completed).Select(s => s.Amount).ToListAsync();

                int usedPrice = 0;

                foreach (var item in getUsePrice)
                {
                    usedPrice = usedPrice + item;
                }

                var remainPrice = getQuotaPrice - usedPrice;

                return new ObjectResult(new { QuotaPrice = getQuotaPrice, UsedPrice = usedPrice, RemainPrice = remainPrice });
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return View();
            //var getUsePrice = _context.Request.Where(s => )
            //return View(getQuotaPrice);


        }

        // GET: Requests/Create
        public async Task<IActionResult> Create()
        {
            //var context = new PrincipalContext(ContextType.Domain);
            //var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);

            //ViewBag.Requester =
            clsAuthenticate clsAuth = new clsAuthenticate();
            var empId = HttpContext.Session.GetString(clsAuth.SessionUserId);
            ViewBag.Requester = await _context.EmpInfo.FirstOrDefaultAsync(s => s.empID == empId);
            ViewBag.Category = new SelectList(CategoryDropDownList(), "Key", "Value");

            var getEmp = await _context.EmpInfo.FirstOrDefaultAsync(s => s.empID == empId);

            DateTime today = DateTime.Today;
            int months = today.Month - getEmp.start_work.Value.Month;
            int years = today.Year - getEmp.start_work.Value.Year;

            if (today.Day < getEmp.start_work.Value.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }
            int days = (today - getEmp.start_work.Value.AddMonths((years * 12) + months)).Days;
            ViewBag.Days = days;
            ViewBag.Months = months;
            ViewBag.Years = years;

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
					_notify.SendEmail(request);

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

            var request = await _context.Request.Include(s => s.Attachments).Where(s => s.Id == id).FirstOrDefaultAsync();

            requestsView.Id = request.Id;
            requestsView.EmployeeId = request.EmployeeId;
            requestsView.Quota = request.Quota;
            requestsView.Used = request.Used;
            requestsView.Remain = request.Remain;
            requestsView.Amount = request.Amount;
            requestsView.RequestNumber = request.RequestNumber;
            requestsView.Detail = request.Detail;
            requestsView.ConfirmDate = request.ConfirmDate;
            requestsView.HRDomainReview = await _context.Workflow.Where(s => s.Step == 2).Select(s => s.ActionDomain).FirstOrDefaultAsync();
            requestsView.ManagerDomainApprove = await _context.EmpInfo.Where(s => s.empID == request.EmployeeId).Select(s => s.ManagerDomainId).FirstOrDefaultAsync();
            requestsView.HRManagerDomainApprove = await _context.Workflow.Where(s => s.Step == 4).Select(s => s.ActionDomain).FirstOrDefaultAsync();
            requestsView.CFODomainApprove = await _context.Workflow.Where(s => s.Step == 5).Select(s => s.ActionDomain).FirstOrDefaultAsync();
            requestsView.AccountDomainApprove = await _context.Workflow.Where(s => s.Step == 6).Select(s => s.ActionDomain).FirstOrDefaultAsync();
            requestsView.WorkflowID = request.WorkflowID;
            requestsView.Attachments = request.Attachments;
            ViewBag.Requester = await _context.EmpInfo.FirstOrDefaultAsync(s => s.empID == request.EmployeeId);
            ViewBag.Category = new SelectList(CategoryDropDownList(), "Key", "Value", request.CategoryID);
            ViewBag.Whom = new SelectList(WhomDropDownListForEdit(request.CategoryID), "Key", "Value", request.WhomID);
            ViewBag.History = (await _context.History.Include(s => s.Workflow.Status).Where(s => s.RequestID == id).OrderBy(s => s.WorkflowID).ToListAsync()).ToArray();
            ViewBag.CountHistory =  _context.History.Where(s => s.RequestID == id).Count();
            ViewBag.CountStatus = _context.Status.Count();
            //ViewBag.Attachment = _context.Attachment

            //เรียกเฉพาะ Status 
            var statusInHistory = ((IEnumerable<History>)ViewBag.History)
                        .Select(h => h.Workflow.Status)
                        .ToList();
            //เช็ค จาก statusInHistory หาค่าที่มากที่สุด  ก็คือจะเป็นคนสุดท้ายที่ Approve 
            //แล้วให้บวก 1 ก็จะเป็นคนที่ให้ Disapprove
            if (statusInHistory.Any(sh => sh.ID == IDStatus.Disapprove))
			{
                var maxStatus = statusInHistory
               .Where(sh => sh.ID < IDStatus.Disapprove)
               .Max(sh => (int)sh.ID) + 1;

                ViewBag.StatusDistinct = _context.Status
               .AsEnumerable()
               .Where(status =>
                  (!statusInHistory.Any(sh => sh.ID == IDStatus.Disapprove) && !statusInHistory.Any(sh => (int)sh.ID == (int)status.ID)) ||
                  (statusInHistory.Any(sh => sh.ID == IDStatus.Disapprove) && (int)status.ID < (int)IDStatus.Disapprove && !statusInHistory.Any(sh => (int)sh.ID == (int)status.ID) && (int)status.ID > (int)maxStatus))
               .OrderBy(s => s.ID)
               .ToArray();
			}
			else
			{
                ViewBag.StatusDistinct = _context.Status
               .AsEnumerable()
               .Where(status =>
                  (!statusInHistory.Any(sh => sh.ID == IDStatus.Disapprove) && !statusInHistory.Any(sh => (int)sh.ID == (int)status.ID)))
               .OrderBy(s => s.ID)
               .ToArray();
            }

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
                    RequestNumber = reqHistory[0].RequestNumber,
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
                report.ConfirmDate = request.ConfirmDate;
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
                report.ConfirmDate = request.ConfirmDate;
            }

            try
            {
                await _context.SaveChangesAsync();
                //_notify.SendEmail(request);
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
        [HttpPost]
        public async Task<IActionResult> CheckdataRequest()
        {
            try
            {
                var getDataRequest = _context.Request.ToList();
                bool hasDocuments = getDataRequest != null && getDataRequest.Count > 0;

                // ดึงข้อมูลเอกสารล่าสุด
                var lastDocument = hasDocuments ?
                    _context.Request.OrderByDescending(r => r.RequestNumber).FirstOrDefault() :
                    null;

                int runningNumber = 1;

                if (lastDocument != null)
                {
                    // มีข้อมูลแล้ว ตรวจสอบว่าเป็นปีเดียวกันหรือไม่
                    var lastDocumentCreatedAt = lastDocument.CreateAt;
                    var currentYear = DateTime.Now.Year;

                    if (lastDocumentCreatedAt.Year == currentYear)
                    {
                        // ถ้าเป็นปีเดียวกัน ก็เพิ่มเลขต่อ
                        runningNumber = int.Parse(lastDocument.RequestNumber.Split('/')[1]) + 1;
                    }
                    // ถ้าไม่เป็นปีเดียวกันให้เริ่มที่ 1
                    else
                    {
                        runningNumber = 1;
                    }
                }

                // สร้างเอกสารใหม่
                var newDocument = new Request
                {
                    RequestNumber = $"{DateTime.Now.Year:D4}/{runningNumber:D4}",
                    // กำหนดค่าอื่น ๆ ตามที่ต้องการ
                };

                // ส่งข้อมูลเอกสารที่สร้างขึ้นให้กับ Ajax
                return Ok(new { RequestNumber = newDocument.RequestNumber });


            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> getHistory()
        //{
        //    try
        //    {
        //        //var getCategory = await _context.DocumentDetail.Where(s => s.CategoryID == categoryID).ToListAsync();

        //        //var getWhom = (from l in _context.History
                             
        //        //               select l.CategoryName
        //        //               ).ToList();

        //        //return StatusCode(200, getWhom);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }

        //}
        private bool RequestExists(Guid id)
        {
            return _context.Request.Any(e => e.Id == id);
        }

        public async Task<FileResult> Viewfile(Guid reportId, int fileId)
        {
            var report = await _context.Request.Include(s => s.Attachments).Where(s => s.Id == reportId).FirstOrDefaultAsync();

            var fileData = report.Attachments.FirstOrDefault(f => f.ID == fileId);
            return File(fileData.Content, fileData.ContentMimeType, fileData.ContentName);

        }
        public async Task<IActionResult> DeleteFile(Guid reportId, int fileId)
        {
            var report = await _context.Request.Include(s => s.Attachments).Where(s => s.Id == reportId).FirstOrDefaultAsync();
            var attachments = report.Attachments.Where(x => x.ID == fileId);
            _context.RemoveRange(attachments);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = reportId });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            //try
            //{
            //    await _report.DeleteFile(reportId, fileId);
            //    var ret = await _report.GetReport(reportId);
            //    return RedirectToAction(nameof(Edit), new { id = reportId });
            //}
            //catch (Exception e)
            //{
            //    return StatusCode(500, e.Message);
            //}

        }
    }
}
