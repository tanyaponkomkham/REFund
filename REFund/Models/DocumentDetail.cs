using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class DocumentDetail
	{
		[Key]
		public int ID { get; set; }
		public int DocumentID { get; set; }
		public int WhomID { get; set; }
		public int CategoryID { get; set; }

		public virtual Document Document { get; set; }
		public virtual Whom Whom { get; set; }
		public virtual Category Category { get; set; }
	}
}
