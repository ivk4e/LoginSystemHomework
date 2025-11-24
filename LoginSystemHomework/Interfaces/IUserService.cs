using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework.Interfaces
{
	public interface IUserService
	{
		public bool UsernameExists(string username);

		void AddUser(string username, string password);
	}
}