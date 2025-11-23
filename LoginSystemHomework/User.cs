using LoginSystemHomework.Db;
using LoginSystemHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework
{
	public class User : IUser
	{
		protected readonly FileDatabase _fileDatabase; // it's protected in order to other child classes to reach and use it

		public User(FileDatabase fileDatabase)
		{
			_fileDatabase = fileDatabase;
		}

		public bool UsernameExists(string username) => _fileDatabase.IsUserExisting(username);
	}
}