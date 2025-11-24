using LoginSystemHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemHomework.Db
{
	public class FileDatabase : IFileDatabase
	{
		private const string _filePath = "users.txt";

		public FileDatabase()
		{
			CreateFileIfNotExists();
		}

		public void CreateFileIfNotExists()
		{
			if (!File.Exists(_filePath))
			{
				using (File.Create(_filePath)) { }
			}
		}

		/// <summary>
		/// Returns all users from the database file as tuple of username and password
		/// </summary>
		public IEnumerable<(string Username, string Password)> GetAllUsers()
		{
			var lines = File.ReadAllLines(_filePath);
			foreach (var line in lines)
			{
				var parts = line.Split(',');
				if (parts.Length == 2)
				{
					yield return (parts[0], parts[1]);
				}
			}
		}

		/// <summary>
		/// Checks whether a given username exists in the database file.
		/// </summary>
		/// <param name="username">Username given from the user.</param>
		/// <returns>
		/// If the username appears in the file, it return <c>true</c>.
		/// Otherwise, returns <c>false</c>.
		/// </returns>
		public bool IsUserExisting(string username)
		{
			foreach (var user in GetAllUsers())
			{
				if (user.Username == username)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Checks whether a username/password pair exists.
		/// </summary>
		public bool ValidateUser(string username, string password)
		{
			foreach (var user in GetAllUsers())
			{
				if (user.Username == username && user.Password == password)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Adds a new user to the database file.
		/// </summary>
		public void AddUser(string username, string password)
		{
			File.AppendAllLines(_filePath, new[] { $"{username},{password}" });
		}
	}
}