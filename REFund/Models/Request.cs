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

		}
		[Key]
		public Guid Id { get; set; }
		//public int ID_Request { get; set; }

		[Display(Name = "Employee ID")]

		public int EmployeeId { get; set; }
		[Required(ErrorMessage = " ID Category1111 is Required")]
		//public int IDCategory { get; set; }
		public string Detail { get; set; }
		public int Amount { get; set; }
		//public int IDWorkflow { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateAt { get; set; }
		public string UpdateBy { get; set; }
		public DateTime UpdateAt { get; set; }
		public DateTime ConfirmDate { get; set; }

		public virtual Category Category { get; set; }
		public virtual Workflow Workflow { get; set; }
		public virtual ICollection<Communication> Communications { get; set; }
		public virtual ICollection<Attachment> Attachments { get; set; }
	}
}
