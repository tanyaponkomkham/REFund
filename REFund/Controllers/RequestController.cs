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
            return View(await _context.Request.ToListAsync());
        }

        // GET: Requests/Details/5
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
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,EmployeeId,Detail,Amount,CreateBy,CreateAt,UpdateBy,UpdateAt,ConfirmDate")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(request);
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
        public async Task<IActionResult> GetQuotaTitle(int categoryID, string empId)
        {
            try
            {
                var getQuotaPrice = await _context.Category.Where(s => s.ID == categoryID).Select(s => s.QuotaPrice).FirstOrDefaultAsync();

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
        public async Task<IActionResult> GetDocumentDetail(int categoryID)
        {
            try
            {
                //var getCategory = await _context.DocumentDetail.Where(s => s.CategoryID == categoryID).ToListAsync();

                var getCategory = (from l in _context.DocumentDetail
                                    join q in _context.Document on l.DocumentID equals q.ID
                                    where l.CategoryID == categoryID
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

        private bool RequestExists(Guid id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}
