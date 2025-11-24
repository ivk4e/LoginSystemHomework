using LoginSystemHomework.Db;
using LoginSystemHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework.Registration
{
	public class RegistrationUser : UserService, IRegistrationUser
	{
		public RegistrationUser() : base()
		{
		}

		public bool Register(string username, string password)
		{
			if (base.UsernameExists(username))
			{
				return false;
			}

			base.AddUser(username, password);
			return true;
		}
	}
}