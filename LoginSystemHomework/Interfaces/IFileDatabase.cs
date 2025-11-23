using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework.Interfaces
{
	public interface IFileDatabase
	{
		public void CreateFileIfNotExists();

		public IEnumerable<(string Username, string Password)> GetAllUsers();

		public bool IsUserExisting(string username);

		public bool ValidateUser(string username, string password);

		public void AddUser(string username, string password);
	}
}