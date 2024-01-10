using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class Category
	{
		public Category()
		{
			Requests = new HashSet<Request>();
			Historys = new HashSet<History>();
			Documents = new HashSet<Document>();
			SubCategorys = new HashSet<SubCategory>();
		}
		[Key]
		public int ID { get; set; }
		public string CategoryName { get; set; }
		public string Status { get; set; }

		
		public virtual ICollection<Document> Documents { get; set; }
		public virtual ICollection<SubCategory> SubCategorys { get; set; }
		public virtual ICollection<Request>  Requests { get; set; }
		public virtual ICollection<History> Historys { get; set; }
	}
}
