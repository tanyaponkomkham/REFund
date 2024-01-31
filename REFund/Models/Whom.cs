using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class Whom
	{
		public Whom()
		{
			DocumentDetails = new HashSet<DocumentDetail>();
			Requests = new HashSet<Request>();
		}
		[Key]
		public int ID { get; set; }
		public string WhomName { get; set; }
		public string Status { get; set; }

		public virtual ICollection<Request> Requests { get; set; }
		public virtual ICollection<DocumentDetail> DocumentDetails { get; set; }
	}
}
