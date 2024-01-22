using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class Workflow
	{
		public Workflow()
		{
			Requests = new HashSet<Request>();
			Historys = new HashSet<History>();
		}
		[Key]
		public int ID { get; set; }
		public int Step { get; set; }
		public string ActionDomain { get; set; }
		public string ActionEmail { get; set; }
		public int Approve { get; set; }
		public int Disapprove { get; set; }

		public virtual Status Status { get; set; }
		public virtual ICollection<Request> Requests { get; set; }
		public virtual ICollection<History> Historys { get; set; }
	}
}
