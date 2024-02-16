using System;
using REFund.Models;
using REFund.Models.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using REFund.Data;
using System.Net.Mail;
using System.Net;

namespace REFund.Services
{
    public class Notify : INotify
    {
        private readonly IConfiguration _conf;
        private readonly CoreContext _db;
        public Notify(CoreContext db, IConfiguration configuration)
        {
            _conf = configuration;
            _db = db;
            //LineMessage = new Dictionary<string, string>();
        }

        private string MailAddress { get; set; }
        //private List<string> MailCc = new List<string>();
        private string MailSubject { get; set; }
        private string MailMessage { get; set; }
        private string MailCC { get; set; }
        public void InvokeEmail()
        {
            var setConfig = _conf.GetSection("EmailConfig");
            try
            {
                var smtp = new SmtpClient
                {
                    Host = setConfig["Host"],
                    Port = Convert.ToInt32(setConfig["Port"]),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(setConfig["FromAddress"], setConfig["Password"])
                };

                var mail = new MailMessage
                {
                    From = new MailAddress(setConfig["FromAddress"])
                };

                mail.To.Add(MailAddress);

                mail.Bcc.Add("tanyaporn.std@senior-thailand.com");
                if(MailCC != null)
				{
                    mail.CC.Add(MailCC);
                }
                
                mail.IsBodyHtml = true;
                mail.Subject = MailSubject;
                mail.Body = MailMessage;

                smtp.Send(mail);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void SendEmail(Request request)
        {

            var informs = new List<string>();

            switch (request.WorkflowID)
            {
                case (int)IDStatus.Request:
                    var HRDomainReview = _db.Workflow.Where(s => s.Step == 2).Select(s => s.ActionDomain).FirstOrDefault();
                    MailSubject = "[iBenefit] - Waiting for your verify";
                    MailMessage = "<strong>Dear " + HRDomainReview + ",</strong>";
                    MailMessage += GetEmailTemplete(request);
                    MailMessage += "<br />";
                    MailMessage += "<br />";
                    // MailMessage += "<div>for more information click <a href='" + setConfig["HttpRootPath"] + "Auth/Index?returnUrl=/Home/Edit/" + request.Id + "'>[Link]</a></div>";
                    var MailHR = _db.Workflow.Where(s => s.Step == 2).Select(s => s.ActionEmail).FirstOrDefault();
                    MailAddress = MailHR;

                    InvokeEmail();
                

                    break;
                case (int)IDStatus.HRReview:

                   var ManagerDomainApprove = _db.EmpInfo.Where(s => s.empID == request.EmployeeId).Select(s => s.ManagerDomainId).FirstOrDefault();
                    MailSubject = "[iBenefit] - Waiting for your verify";
                    MailMessage = "<strong>Dear " + ManagerDomainApprove + ",</strong>";
                    MailMessage += GetEmailTemplete(request);
                    MailMessage += "<br />";
                    MailMessage += "<br />";
                    // MailMessage += "<div>for more information click <a href='" + setConfig["HttpRootPath"] + "Auth/Index?returnUrl=/Home/Edit/" + request.Id + "'>[Link]</a></div>";
                    var MailManager = _db.EmpInfo.Where(s => s.domain_name == ManagerDomainApprove).Select(s => s.email).FirstOrDefault();
                    MailAddress = MailManager;

                    InvokeEmail();

                    break;
                case (int)IDStatus.ManagerReview:
                    var HRManagerDomainApprove = _db.Workflow.Where(s => s.Step == 4).Select(s => s.ActionDomain).FirstOrDefault();
                    MailSubject = "[iBenefit] - Waiting for your verify";
                    MailMessage = "<strong>Dear " + HRManagerDomainApprove + ",</strong>";
                    MailMessage += GetEmailTemplete(request);
                    MailMessage += "<br />";
                    //MailMessage += RequestItemTemplate(request);
                    MailMessage += "<br />";
                    // MailMessage += "<div>for more information click <a href='" + setConfig["HttpRootPath"] + "Auth/Index?returnUrl=/Home/Edit/" + request.Id + "'>[Link]</a></div>";
                    var MailHRManager = _db.Workflow.Where(s => s.Step == 4).Select(s => s.ActionEmail).FirstOrDefault();
                    MailAddress = MailHRManager;

                    InvokeEmail();

                    break;
                case (int)IDStatus.HRManagerReview:
                    var CFODomainApprove = _db.Workflow.Where(s => s.Step == 5).Select(s => s.ActionDomain).FirstOrDefault();
                    MailSubject = "[iBenefit] - Waiting for your verify";
                    MailMessage = "<strong>Dear " + CFODomainApprove + ",</strong>";
                    MailMessage += GetEmailTemplete(request);
                    MailMessage += "<br />";
                    //MailMessage += RequestItemTemplate(request);
                    MailMessage += "<br />";
                    // MailMessage += "<div>for more information click <a href='" + setConfig["HttpRootPath"] + "Auth/Index?returnUrl=/Home/Edit/" + request.Id + "'>[Link]</a></div>";
                    var MailCFO = _db.Workflow.Where(s => s.Step == 5).Select(s => s.ActionEmail).FirstOrDefault();
                    MailAddress = MailCFO;

                    InvokeEmail();
                    break;
                case (int)IDStatus.CFOReview:
                    var AccountDomain = _db.Workflow.Where(s => s.Step == 6).Select(s => s.ActionDomain).FirstOrDefault();
                    MailSubject = "[iBenefit] - Waiting for your verify";
                    MailMessage = "<strong>Dear " + AccountDomain + ",</strong>";
                    MailMessage += GetEmailTemplete(request);
                    MailMessage += "<br />";
                    //MailMessage += RequestItemTemplate(request);
                    MailMessage += "<br />";
                    // MailMessage += "<div>for more information click <a href='" + setConfig["HttpRootPath"] + "Auth/Index?returnUrl=/Home/Edit/" + request.Id + "'>[Link]</a></div>";
                    var MailAccount = _db.Workflow.Where(s => s.Step == 6).Select(s => s.ActionEmail).FirstOrDefault();
                    MailAddress = MailAccount;

                    InvokeEmail();
                    break;
                case (int)IDStatus.Completed:
                    var emp = _db.EmpInfo.Where(w => w.empID == request.EmployeeId).FirstOrDefault();
                    MailSubject = "[iBenefit] - The request has been completed.";
                    MailMessage = "<strong>Dear " + emp.domain_name + ",</strong>";
                    MailMessage += GetEmailTemplete(request);
                    MailMessage += "<br />";
                    MailMessage += "<br />";
					// MailMessage += "<div>for more information click <a href='" + setConfig["HttpRootPath"] + "Auth/Index?returnUrl=/Home/Edit/" + request.Id + "'>[Link]</a></div>";
					var MailAccount2 = _db.Workflow.Where(s => s.Step == 6).Select(s => s.ActionEmail).FirstOrDefault();
                    var EmailHR = _db.Workflow.Where(s => s.Step == 2).Select(s => s.ActionEmail).FirstOrDefault();
                    MailAddress = EmailHR;
                    MailCC = MailAccount2;

                    InvokeEmail();
                    break;
                case (int)IDStatus.Disapprove:
                    var emp2 = _db.EmpInfo.Where(w => w.empID == request.EmployeeId).FirstOrDefault();
                    MailSubject = "[iBenefit] - Your request was rejected.";
                    MailMessage = "<strong>Dear " + emp2.domain_name + ",</strong>";
                    MailMessage += GetEmailTemplete(request);
                    MailMessage += "<br />";
                    MailMessage += "<br />";
                    // MailMessage += "<div>for more information click <a href='" + setConfig["HttpRootPath"] + "Auth/Index?returnUrl=/Home/Edit/" + request.Id + "'>[Link]</a></div>";

                    MailAddress = emp2.email;

                    InvokeEmail();
                    break;
               
            }
        }
        //public string RequestItemTemplate(Request request)
        //{
        //    int i = 1;
        //    decimal? sumAmount = 0;
        //    var temp = "<table style='border-collapse: collapse;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;overflow-wrap: anywhere;width: -webkit-fill-available;'>"
        //        + "         <thead>"
        //        + "             <tr>"
        //        + "                 <th style='width: 2 %;text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>No</th>"
        //        + "                 <th style='width: 10 %;text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>When</th>"
        //        + "                 <th style='width: 10 %;text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>What</th>"
        //        + "                 <th style='width: 10 %;text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>Amount (THB)</th>"
        //        + "                 <th style='width: 10 %;text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>Where</th>"
        //        + "                 <th style='width: 10 %;text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>Who</th>"
        //        + "                 <th style='width: 10 %;text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>Why</th>"
        //        + "             </tr>"
        //        + "         </thead>"
        //        + "         <tbody>";
        //    foreach (var item in request.RequestItems)
        //    {

        //        temp += "      <tr>"
        //       + $"                 <td style='text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>{i}.</td>"
        //       + $"                 <td style='text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>{item.When:dd/MM/yyyy}</td>"
        //       + $"                 <td style='text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>{item.What}</td>"
        //       + $"                 <td style='text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>{item.AmountTHB?.ToString("N2")}</td>"
        //       + $"                 <td style='text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>{item.Where}</td>"
        //       + $"                 <td style='text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>{item.Who}</td>"
        //       + $"                 <td style='text-align: center;padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>{item.Why}</td>"
        //       + "             </tr>";
        //        i++;
        //        if (i == 1)
        //        {
        //            sumAmount = item.AmountTHB;

        //        }
        //        else
        //        {
        //            sumAmount = sumAmount + item.AmountTHB;
        //        }
        //    }

        //    var returnMoney = sumAmount - request.CompanyCashAdvance;
        //    temp += "   </tbody>"
        //     + "        <tfoot style='padding: 0.75rem;vertical-align: top;border-top: 1px solid #dee2e6;'>"
        //     + "             <tr>"
        //     + "                 <td colspan='3' style='text-align: right;'><span>Total</span></td>"
        //     + $"                 <td colspan='1' style='text-align: center;'><span>{sumAmount?.ToString("N2")}</span></td>"
        //     + "             </tr>"
        //     + "             <tr>"
        //     + "                 <td colspan='3' style='text-align: right;'><span>Company Cash Advance</span></td>"
        //     + $"                 <td colspan='1' style='text-align: center;'><span>{request.CompanyCashAdvance?.ToString("N2")}</span></td>"
        //     + "             </tr>"
        //     + "             <tr>"
        //     + "                 <td colspan='3' style='text-align: right;'><span>+Paid to Employee/-Return to Company</span></td>"
        //     + $"                 <td colspan='1' style='text-align: center;'><span>{returnMoney?.ToString("N2") /*string.Format("{0:#,0.####}", (returnMoney))*/}</span></td>"
        //     + "             </tr>"
        //     + "        </tfoot>"
        //     + "    </table>";
        //    return temp;
        //}
        //public void SendCommunicationEmail(Request request)
        //{

        //    var informs = new List<string>();

        //    MailSubject = "[iReimburse] - need more details";
        //    MailMessage = "<strong>Dear All concern,</strong>";
        //    MailMessage += GetEmailTemplete(request);
        //    MailMessage += "<br />";
        //    MailMessage += RequestItemTemplate(request);
        //    MailMessage += "<br />";
        //    // MailMessage += "<div>for more information click <a href='" + setConfig["HttpRootPath"] + "Auth/Index?returnUrl=/Home/Edit/" + request.Id + "'>[Link]</a></div>";

        //    MailMessage += TempleteCommunication(request);


        //    MailAddress = string.Join(",", request.RequestEvents.Select(s => s.CreatorEmail));

        //    if (!string.IsNullOrWhiteSpace(MailAddress))
        //    {
        //        InvokeEmail();
        //    }
        //}
        private string GetEmailTemplete(Request request)
        {
            var category = _db.Category.Where(c => c.ID == request.CategoryID).Select(s => s.CategoryName).FirstOrDefault();
            var documentDetail = _db.RequestDocumentDetail.Where(w => w.RequestID == request.Id).Select(s => s.DocumentID).ToList();
            var document = _db.Document.Where(w => documentDetail.Contains(w.ID)).Select(s => s.DocumentName).ToList();
            var whom = _db.Whom.Where(w => w.ID == request.WhomID).FirstOrDefault(); 
            var emp3 = _db.EmpInfo.Where(w => w.empID == request.EmployeeId).FirstOrDefault();
            var setConfig = _conf.GetSection("SiteInfo");
            var ret = " <table> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Request No :</td> "
                    + $"      <td><a href='https://localhost:44355/'>{request.RequestNumber}</a></td>  "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Employee :</td> "
                    + $"      <td> { emp3.eng_fullname } </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Department :</td> "
                    + $"      <td> { emp3.Dept_Name } </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Position:</td> "
                    + $"      <td> { emp3.Position_Name } </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Request :</td> "
                    + $"      <td> { category} </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>To Whom :</td> "
                    + $"      <td> { whom.WhomName } </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Quota (BATH) :</td> "
                    + $"      <td> { request.Quota?.ToString("N2")} </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Used (BATH) :</td> "
                    + $"      <td> { request.Used?.ToString("N2")} </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Remain (BATH) :</td> "
                    + $"      <td> { request.Remain?.ToString("N2")} </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Amount :</td> "
                    + $"      <td> { request.Amount.ToString("N2")} </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Detail :</td> "
                    + $"      <td > { request.Detail } </td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "      <td style='text-align: left;;font-weight:bold'>Date :</td> "
                    + $"      <td >{ request.CreateAt:dd/MM/yyyy}</td> "
                    + "  </tr> "
                    + "  <tr> "
                    + "       <th style='text-align: left;;font-weight:bold'>Document :</th>"
                    + "      <td >------------------------------------------------------</td> "
                    + "  </tr> ";
                    foreach (var documentName in document)
                    {
                            ret += "<tr> "
                                + "<th></th> "
                                + $"<td>{documentName}</td>"
                                + "</tr> ";
                    }
                    ret += " <th ></th>"
                        + "  <td >------------------------------------------------------</td> "
                        + "</table> ";

          
            return ret;
        }
        //private string TempleteCommunication(RequestWithItems request)
        //{
        //    string ret;
        //    ret = "<div style='border-radius: 0px; box - shadow: 0 0 1px rgb(0 0 0 / 13 %), 0 1px 3px rgb(0 0 0 / 20 %); margin-bottom: 1rem; position: relative; display: -ms-flexbox; display: flex; -ms-flex-direction: column; flex-direction: column; min-width: 0; word-wrap: break-word; background-color: #fff; background-clip: border-box; border: 0 solid rgba(0,0,0,.125); border-radius: 0.25rem; '>";
        //    ret += "        <div style='background-color: transparent; border-bottom: 1px solid rgba(0, 0, 0, .125); position: relative; border-top-left-radius: 0.25rem; border-top-right-radius: 0.25rem;'>";
        //    ret += "            <strong>Communication</strong> ";
        //    ret += "        </div>";
        //    ret += "        <div style='overflow-x: hidden; padding: 0; position: relative; flex: 1 1 auto; min-height: 1px; padding: 1.25rem;'>";
        //    foreach (var com in request.Communications.OrderByDescending(o => o.CreatedDate))
        //    {
        //        ret += "            <div style='padding: 5px;'>";
        //        ret += "                <div style=' display: block; font-size: .875rem; margin-bottom: 2px;'>";
        //        ret += $"                    <strong>{com.CreatedDate:dd/MM/yyyy HH:mm:ss}({com.CreatorDomainName}): </strong>";
        //        ret += "                </div>";
        //        ret += "                <div style='border-radius: 0.3rem; background-color: #d2d6de; border: 1px solid #d2d6de; color: #444; margin: 2px 0 0 5px; padding: 5px 10px; position: relative;'>";
        //        ret += $"                    <small>{com.Detail}</small>";
        //        ret += "                </div>";
        //        ret += "           </div>";

        //    }
        //    ret += "      </div>";
        //    ret += "</div>";


        //    return ret;
        //}
    }
}
