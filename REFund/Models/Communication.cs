using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class Communication
	{
		[Key]
		public int ID { get; set; }
		public int EmployeeId { get; set; }
		public DateTime Date { get; set; }
		public string Detail { get; set; }


		public virtual Request Request { get; set; }
	}
}
