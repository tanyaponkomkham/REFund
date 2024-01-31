using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class Status
	{
		public Status()
		{
			Workflows = new HashSet<Workflow>();

		}
		[Key]
		public IDStatus ID { get; set; }
		public string StatusName { get; set; }
		public string BackgroundColor { get; set; }
		public string FontColor { get; set; }

		public virtual ICollection<Workflow> Workflows { get; set; }

	}

	public enum IDStatus
	{
		Request = 1,
	    HRReview = 2,
		ManagerReview = 3,
		HRManagerReview = 4,
		CFOReview = 5,
		Completed = 6,
		Disapprove = 7,
	}
}
