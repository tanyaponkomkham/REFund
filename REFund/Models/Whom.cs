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
			Documents = new HashSet<Document>();

		}
		[Key]
		public int ID { get; set; }
		public string WhomName { get; set; }
		public string Status { get; set; }

		public virtual ICollection<Document> Documents { get; set; }
	}
}
