using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Models
{
	public class EmpInfo
	{
        public string empID { get; set; }
        public string domain_name { get; set; }
        public string thai_fullname { get; set; }
        public string eng_fullname { get; set; }
        public string Position_Name { get; set; }
        public string Dept_Name { get; set; }
        public string supervisor_id { get; set; }
        public string email { get; set; }
        public string ManagerDomainId { get; set; }
        public string ManagerFullnameEng { get; set; }
        public DateTime? start_work { get; set; }
    }
}
