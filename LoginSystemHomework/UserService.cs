using LoginSystemHomework.Db;
using LoginSystemHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework
{
	public class UserService : IUserService
	{
		private static FileDatabase _fileDatabase = new FileDatabase();

		public bool UsernameExists(string username) => _fileDatabase.IsUserExisting(username);

		public void AddUser(string username, string password) => _fileDatabase.AddUser(username, password);
	}
}