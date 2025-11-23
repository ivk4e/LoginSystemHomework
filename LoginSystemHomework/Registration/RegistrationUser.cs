using LoginSystemHomework.Db;
using LoginSystemHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework.Registration
{
	public class RegistrationUser : User, IRegistrationUser
	{
		public RegistrationUser(FileDatabase fileDatabase) : base(fileDatabase)
		{
		}

		public bool Register(string username, string password)
		{
			if (UsernameExists(username))
			{
				return false;
			}

			base._fileDatabase.AddUser(username, password);
			return true;
		}
	}
}