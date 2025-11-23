using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework.Interfaces
{
	public interface ILoginUser
	{
		public bool ValidateLogin(string username, string password);
	}
}