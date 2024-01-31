using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class Request
	{
		public Request()
		{
			Communications = new HashSet<Communication>();
			Attachments = new HashSet<Attachment>();
			Historys = new HashSet<History>();
			RequestDocumentDetails = new HashSet<RequestDocumentDetail>();

		}
		[Key]
		public Guid Id { get; set; }


		[Display(Name = "Employee ID")]

		public string EmployeeId { get; set; }
		[Required(ErrorMessage = " ID Category1111 is Required")]
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

		public virtual Category Category { get; set; }
		public virtual Workflow Workflow { get; set; }
		//public virtual Whom Whom { get; set; }
		public virtual ICollection<Communication> Communications { get; set; }
		public virtual ICollection<Attachment> Attachments { get; set; }
		public virtual ICollection<RequestDocumentDetail> RequestDocumentDetails { get; set; }
		public virtual ICollection<History> Historys { get; set; }

	}
}
