using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class RequestDocumentDetail
	{
		[Key]
		public int ID { get; set; }
		public int DocumentID { get; set; }
		public string DocumentName { get; set; }
		public Guid RequestID { get; set; }
		public virtual Request Request { get; set; }
	}
}
