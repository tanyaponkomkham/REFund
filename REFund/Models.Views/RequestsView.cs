using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models.Views
{
	public class RequestsView
	{
		//public RequestsView()
		//{
		//	Communications = new HashSet<Communication>();
		//	Attachments = new HashSet<Attachment>();
		//	Historys = new HashSet<History>();
		//	RequestDocumentDetails = new HashSet<RequestDocumentDetail>();

		//}
		public Guid Id { get; set; }
		public string EmployeeId { get; set; }
		public string Detail { get; set; }
		public int? Quota { get; set; }
		public int? Used { get; set; }
		public int? Remain { get; set; }
		public int Amount { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateAt { get; set; }
		public string UpdateBy { get; set; }
		public DateTime UpdateAt { get; set; }
		public DateTime ConfirmDate { get; set; }

		public int CategoryID { get; set; }
		public int WorkflowID { get; set; }
		public int WhomID { get; set; }

		public string HRDomainReview { get; set; }
		public string ManagerDomainApprove { get; set; }
		public string HRManagerDomainApprove { get; set; }
		public string CFODomainApprove { get; set; }
		public string AccountDomainApprove { get; set; }

		//public virtual Category Category { get; set; }
		//public virtual Workflow Workflow { get; set; }
		////public virtual Whom Whom { get; set; }
		//public virtual ICollection<Communication> Communications { get; set; }
		//public virtual ICollection<Attachment> Attachments { get; set; }
		//public virtual ICollection<RequestDocumentDetail> RequestDocumentDetails { get; set; }
		//public virtual ICollection<History> Historys { get; set; }
	}
}
