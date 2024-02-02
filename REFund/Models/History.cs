using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class History
	{

		[Key]
		public int ID { get; set; }
		public string RequestNumber { get; set; }
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
		public string Comment { get; set; }
		public int WorkflowID { get; set; }
		public int CategoryID { get; set; }
		public int WhomID { get; set; }
		public Guid RequestID { get; set; }


		public virtual Whom Whom { get; set; }
		public virtual Workflow Workflow { get; set; }
		public virtual Category Category { get; set; }
		public virtual Request Request { get; set; }
	}
}
