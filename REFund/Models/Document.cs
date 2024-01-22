using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class Document
	{
		public Document()
		{
			DocumentDetails = new HashSet<DocumentDetail>();
			
		}
		[Key]
		public int ID { get; set; }
		public string DocumentName { get; set; }
		//public virtual Whom Whom { get; set; }
		//public virtual Category Category { get; set; }

		public virtual ICollection<DocumentDetail> DocumentDetails { get; set; }
	}
}
