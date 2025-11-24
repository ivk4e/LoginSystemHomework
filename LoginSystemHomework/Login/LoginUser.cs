using LoginSystemHomework.Db;
using LoginSystemHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework.Login
{
	public class LoginUser : UserService, ILoginUser
	{
		public LoginUser() : base()
		{
		}

		public bool ValidateLogin(string username, string password) => base.UsernameExists(username);
	}
}