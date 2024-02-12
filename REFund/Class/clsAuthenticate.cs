using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Class
{
	public class clsAuthenticate
	{
		public bool Login(string path,string domain,string password)
		{
			using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
			{
				return context.ValidateCredentials(domain, password);
			}

			
		}
	}
}
