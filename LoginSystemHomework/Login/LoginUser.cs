using LoginSystemHomework.Db;
using LoginSystemHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework.Login
{
	public class LoginUser : User, ILoginUser
	{
		public LoginUser(FileDatabase fileDatabase) : base(fileDatabase)
		{
		}

		public bool ValidateLogin(string username, string password) => base._fileDatabase.ValidateUser(username, password);
	}
}