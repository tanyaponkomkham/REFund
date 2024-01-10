using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class SubCategory
	{
		
		[Key]
		public int ID { get; set; }
		public string Year { get; set; }
		public int Amount { get; set; }
		public int Level { get; set; }
		public virtual Category Category { get; set; }
	}
}
