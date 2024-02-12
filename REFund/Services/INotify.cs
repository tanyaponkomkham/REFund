using REFund.Models;
using REFund.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REFund.Services
{
	public interface INotify
	{
		void SendEmail(Request request);
	}
}
