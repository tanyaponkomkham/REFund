using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class Attachment
	{
		[Key]
		public int ID { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public byte[] Content { get; set; }
		public string ContentName { get; set; }
		public string ContentMimeType { get; set; }

		public Guid RequestId { get; set; }
		public virtual Request Request { get; set; }
	}
}
